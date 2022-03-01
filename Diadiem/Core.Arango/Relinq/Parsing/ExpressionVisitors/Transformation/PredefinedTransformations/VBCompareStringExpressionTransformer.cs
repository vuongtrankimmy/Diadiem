// Copyright (c) rubicon IT GmbH, www.rubicon.eu
//
// See the NOTICE file distributed with this work for additional information
// regarding copyright ownership.  rubicon licenses this file to you under 
// the Apache License, Version 2.0 (the "License"); you may not use this 
// file except in compliance with the License.  You may obtain a copy of the 
// License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the 
// License for the specific language governing permissions and limitations
// under the License.
// 

using System;
using System.Linq.Expressions;
using System.Reflection;
using Core.Arango.Relinq.Clauses.Expressions;
using Core.Arango.Relinq.Utilities;
using Remotion.Utilities;

namespace Core.Arango.Relinq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations
{
    /// <summary>
    ///     Detects expressions calling the CompareString method used by Visual Basic .NET, and replaces them with
    ///     <see cref="VBStringComparisonExpression" /> instances. Providers use this transformation to be able to handle VB
    ///     string comparisons
    ///     more easily. See <see cref="VBStringComparisonExpression" /> for details.
    /// </summary>
    internal class VBCompareStringExpressionTransformer : IExpressionTransformer<BinaryExpression>
    {
        private const string c_vbOperatorsClassName = "Microsoft.VisualBasic.CompilerServices.Operators";

        private const string c_vbEmbeddedOperatorsClassName =
            "Microsoft.VisualBasic.CompilerServices.EmbeddedOperators";

        private const string c_vbCompareStringOperatorMethodName = "CompareString";

        private static readonly MethodInfo s_stringCompareToMethod =
            typeof(string).GetRuntimeMethodChecked("CompareTo", new[] {typeof(string)});

        public ExpressionType[] SupportedExpressionTypes
        {
            get
            {
                return new[]
                {
                    ExpressionType.Equal,
                    ExpressionType.NotEqual,
                    ExpressionType.LessThan,
                    ExpressionType.GreaterThan,
                    ExpressionType.LessThanOrEqual,
                    ExpressionType.GreaterThanOrEqual
                };
            }
        }

        public Expression Transform(BinaryExpression expression)
        {
            ArgumentUtility.CheckNotNull("expression", expression);
            if (expression.Left is MethodCallExpression leftSideAsMethodCallExpression && IsVBOperator(leftSideAsMethodCallExpression.Method,
                c_vbCompareStringOperatorMethodName))
            {
                var rightSideAsConstantExpression = expression.Right as ConstantExpression;
                Assertion.DebugAssert(
                    rightSideAsConstantExpression != null && rightSideAsConstantExpression.Value is int @int &&
                    @int == 0,
                    "The right side of the binary expression has to be a constant expression with value 0.");

                var leftSideArgument2AsConstantExpression =
                    leftSideAsMethodCallExpression.Arguments[2] as ConstantExpression;
                Assertion.DebugAssert(
                    leftSideArgument2AsConstantExpression != null &&
                    leftSideArgument2AsConstantExpression.Value is bool,
                    "The second argument of the method call expression has to be a constant expression with a boolean value.");

                return GetExpressionForNodeType(expression, leftSideAsMethodCallExpression,
                    leftSideArgument2AsConstantExpression);
            }

            return expression;
        }

        private static Expression GetExpressionForNodeType(
            BinaryExpression expression, MethodCallExpression leftSideAsMethodCallExpression,
            ConstantExpression leftSideArgument2AsConstantExpression)
        {
            BinaryExpression binaryExpression;
            switch (expression.NodeType)
            {
                case ExpressionType.Equal:
                    binaryExpression = Expression.Equal(leftSideAsMethodCallExpression.Arguments[0],
                        leftSideAsMethodCallExpression.Arguments[1]);
                    return new VBStringComparisonExpression(binaryExpression,
                        (bool)leftSideArgument2AsConstantExpression.Value);
                case ExpressionType.NotEqual:
                    binaryExpression = Expression.NotEqual(leftSideAsMethodCallExpression.Arguments[0],
                        leftSideAsMethodCallExpression.Arguments[1]);
                    return new VBStringComparisonExpression(binaryExpression,
                        (bool) leftSideArgument2AsConstantExpression.Value);
            }

            var methodCallExpression = Expression.Call(
                leftSideAsMethodCallExpression.Arguments[0],
                s_stringCompareToMethod, leftSideAsMethodCallExpression.Arguments[1]);
            var vbExpression = new VBStringComparisonExpression(methodCallExpression,
                (bool)leftSideArgument2AsConstantExpression.Value);

            if (expression.NodeType == ExpressionType.GreaterThan)
                return Expression.GreaterThan(vbExpression, Expression.Constant(0));
            if (expression.NodeType == ExpressionType.GreaterThanOrEqual)
                return Expression.GreaterThanOrEqual(vbExpression, Expression.Constant(0));
            if (expression.NodeType == ExpressionType.LessThan)
                return Expression.LessThan(vbExpression, Expression.Constant(0));
            if (expression.NodeType == ExpressionType.LessThanOrEqual)
                return Expression.LessThanOrEqual(vbExpression, Expression.Constant(0));

            throw new NotSupportedException(
                string.Format("Binary expression with node type '{0}' is not supported in a VB string comparison.",
                    expression.NodeType));
        }

        private static bool IsVBOperator(MethodInfo operatorMethod, string operatorName)
        {
            var operatorTypeName = operatorMethod.DeclaringType.FullName;
            return (operatorTypeName == c_vbOperatorsClassName || operatorTypeName == c_vbEmbeddedOperatorsClassName)
                   && operatorMethod.Name == operatorName;
        }
    }
}