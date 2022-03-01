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

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Core.Arango.Relinq.Clauses;
using Core.Arango.Relinq.Clauses.ResultOperators;
using Core.Arango.Relinq.Utilities;

namespace Core.Arango.Relinq.Parsing.Structure.IntermediateModel
{
    /// <summary>
    ///     Represents a <see cref="MethodCallExpression" /> for
    ///     <see
    ///         cref="Queryable.Concat{TSource}(System.Linq.IQueryable{TSource},System.Collections.Generic.IEnumerable{TSource})" />
    ///     .
    ///     It is generated by <see cref="ExpressionTreeParser" /> when an <see cref="Expression" /> tree is parsed.
    ///     When this node is used, it usually follows (or replaces) a <see cref="SelectExpressionNode" /> of an
    ///     <see cref="IExpressionNode" /> chain that
    ///     represents a query.
    /// </summary>
    internal sealed class ConcatExpressionNode : QuerySourceSetOperationExpressionNodeBase
    {
        public ConcatExpressionNode(MethodCallExpressionParseInfo parseInfo, Expression source2)
            : base(parseInfo, source2)
        {
        }

        public static IEnumerable<MethodInfo> GetSupportedMethods()
        {
            return ReflectionUtility.EnumerableAndQueryableMethods.WhereNameMatches("Concat");
        }

        protected override ResultOperatorBase CreateSpecificResultOperator()
        {
            return new ConcatResultOperator(AssociatedIdentifier, ItemType, Source2);
        }
    }
}