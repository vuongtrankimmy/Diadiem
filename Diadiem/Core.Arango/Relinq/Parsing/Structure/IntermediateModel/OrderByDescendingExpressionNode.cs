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
using Core.Arango.Relinq.Utilities;
using Remotion.Utilities;

namespace Core.Arango.Relinq.Parsing.Structure.IntermediateModel
{
    /// <summary>
    ///     Represents a <see cref="MethodCallExpression" /> for
    ///     <see
    ///         cref="Queryable.OrderByDescending{TSource,TKey}(System.Linq.IQueryable{TSource},System.Linq.Expressions.Expression{System.Func{TSource,TKey}})" />
    ///     .
    ///     It is generated by <see cref="ExpressionTreeParser" /> when an <see cref="Expression" /> tree is parsed.
    /// </summary>
    internal sealed class OrderByDescendingExpressionNode : MethodCallExpressionNodeBase
    {
        private readonly ResolvedExpressionCache<Expression> _cachedSelector;

        public OrderByDescendingExpressionNode(MethodCallExpressionParseInfo parseInfo, LambdaExpression keySelector)
            : base(parseInfo)
        {
            ArgumentUtility.CheckNotNull("keySelector", keySelector);

            if (keySelector.Parameters.Count != 1)
                throw new ArgumentException("KeySelector must have exactly one parameter.", "keySelector");

            KeySelector = keySelector;
            _cachedSelector = new ResolvedExpressionCache<Expression>(this);
        }

        public LambdaExpression KeySelector { get; }

        public static IEnumerable<MethodInfo> GetSupportedMethods()
        {
            return ReflectionUtility.EnumerableAndQueryableMethods.WhereNameMatches("OrderByDescending")
                .WithoutComparer();
        }

        public Expression GetResolvedKeySelector(ClauseGenerationContext clauseGenerationContext)
        {
            return _cachedSelector.GetOrCreate(r =>
                r.GetResolvedExpression(KeySelector.Body, KeySelector.Parameters[0], clauseGenerationContext));
        }

        public override Expression Resolve(
            ParameterExpression inputParameter, Expression expressionToBeResolved,
            ClauseGenerationContext clauseGenerationContext)
        {
            ArgumentUtility.CheckNotNull("inputParameter", inputParameter);
            ArgumentUtility.CheckNotNull("expressionToBeResolved", expressionToBeResolved);

            // this simply streams its input data to the output without modifying its structure, so we resolve by passing on the data to the previous node
            return Source.Resolve(inputParameter, expressionToBeResolved, clauseGenerationContext);
        }

        protected override void ApplyNodeSpecificSemantics(QueryModel queryModel,
            ClauseGenerationContext clauseGenerationContext)
        {
            ArgumentUtility.CheckNotNull("queryModel", queryModel);

            var clause = new OrderByClause();
            clause.Orderings.Add(new Ordering(GetResolvedKeySelector(clauseGenerationContext), OrderingDirection.Desc));
            queryModel.BodyClauses.Add(clause);
        }
    }
}