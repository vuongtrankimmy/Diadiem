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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Core.Arango.Relinq.Clauses;
using Core.Arango.Relinq.Clauses.ResultOperators;
using Core.Arango.Relinq.Parsing.ExpressionVisitors;
using Core.Arango.Relinq.Utilities;
using Remotion.Utilities;

namespace Core.Arango.Relinq.Parsing.Structure.IntermediateModel
{
    /// <summary>
    ///     Represents a <see cref="MethodCallExpression" /> for
    ///     <see cref="Queryable.OfType{TResult}" /> and <see cref="Enumerable.OfType{TResult}" />.
    ///     It is generated by <see cref="ExpressionTreeParser" /> when an <see cref="Expression" /> tree is parsed.
    /// </summary>
    internal sealed class OfTypeExpressionNode : ResultOperatorExpressionNodeBase
    {
        public OfTypeExpressionNode(MethodCallExpressionParseInfo parseInfo)
            : base(parseInfo, null, null)
        {
        }

        public Type SearchedItemType => ParsedExpression.Method.GetGenericArguments()[0];

        public static IEnumerable<MethodInfo> GetSupportedMethods()
        {
            return ReflectionUtility.EnumerableAndQueryableMethods.WhereNameMatches("OfType");
        }

        public override Expression Resolve(ParameterExpression inputParameter, Expression expressionToBeResolved,
            ClauseGenerationContext clauseGenerationContext)
        {
            ArgumentUtility.CheckNotNull("inputParameter", inputParameter);
            ArgumentUtility.CheckNotNull("expressionToBeResolved", expressionToBeResolved);

            var convertExpression = Expression.Convert(inputParameter, SearchedItemType);
            var expressionWithCast =
                ReplacingExpressionVisitor.Replace(inputParameter, convertExpression, expressionToBeResolved);
            return Source.Resolve(inputParameter, expressionWithCast, clauseGenerationContext);
        }

        protected override ResultOperatorBase CreateResultOperator(ClauseGenerationContext clauseGenerationContext)
        {
            return new OfTypeResultOperator(SearchedItemType);
        }
    }
}