﻿// Copyright (c) rubicon IT GmbH, www.rubicon.eu
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
using Core.Arango.Relinq.Parsing;
using Core.Arango.Relinq.Parsing.ExpressionVisitors;
using Core.Arango.Relinq.Utilities;
using Remotion.Utilities;

namespace Core.Arango.Relinq.Clauses.Expressions
{
#if !NET_3_5
    /// <summary>
    ///     Wraps an exception whose partial evaluation caused an exception.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         When <see cref="PartialEvaluatingExpressionVisitor" /> encounters an exception while evaluating an independent
    ///         expression subtree, it
    ///         will wrap the subtree within a <see cref="PartialEvaluationExceptionExpression" />. The wrapper contains both
    ///         the <see cref="Exception" />
    ///         instance and the <see cref="EvaluatedExpression" /> that caused the exception.
    ///     </para>
    ///     <para>
    ///         To explicitly support this expression type, implement
    ///         <see cref="IPartialEvaluationExceptionExpressionVisitor" />.
    ///         To ignore this wrapper and only handle the inner <see cref="EvaluatedExpression" />, call the
    ///         <see cref="Reduce" /> method and visit the result.
    ///     </para>
    ///     <para>
    ///         Subclasses of <see cref="ThrowingExpressionVisitor" /> that do not implement
    ///         <see cref="IPartialEvaluationExceptionExpressionVisitor" /> will,
    ///         by default, automatically reduce this expression type to the <see cref="EvaluatedExpression" /> in the
    ///         <see cref="ThrowingExpressionVisitor.VisitExtension" /> method.
    ///     </para>
    ///     <para>
    ///         Subclasses of <see cref="RelinqExpressionVisitor" /> that do not implement
    ///         <see cref="IPartialEvaluationExceptionExpressionVisitor" /> will,
    ///         by default, ignore this expression and visit its child expressions via the
    ///         <see cref="ExpressionVisitor.VisitExtension" /> and
    ///         <see cref="VisitChildren" /> methods.
    ///     </para>
    /// </remarks>
#else
  /// <summary>
  /// Wraps an exception whose partial evaluation caused an exception.
  /// </summary>
  /// <remarks>
  /// <para>
  /// When <see cref="PartialEvaluatingExpressionVisitor"/> encounters an exception while evaluating an independent expression subtree, it
  /// will wrap the subtree within a <see cref="PartialEvaluationExceptionExpression"/>. The wrapper contains both the <see cref="Exception"/> 
  /// instance and the <see cref="EvaluatedExpression"/> that caused the exception.
  /// </para>
  /// <para>
  /// To explicitly support this expression type, implement  <see cref="IPartialEvaluationExceptionExpressionVisitor"/>.
  /// To ignore this wrapper and only handle the inner <see cref="EvaluatedExpression"/>, call the <see cref="Reduce"/> method and visit the result.
  /// </para>
  /// <para>
  /// Subclasses of <see cref="ThrowingExpressionVisitor"/> that do not implement <see cref="IPartialEvaluationExceptionExpressionVisitor"/> will, 
  /// by default, automatically reduce this expression type to the <see cref="EvaluatedExpression"/> in the 
  /// <see cref="ThrowingExpressionVisitor.VisitExtension"/> method.
  /// </para>
  /// <para>
  /// Subclasses of <see cref="RelinqExpressionVisitor"/> that do not implement <see cref="IPartialEvaluationExceptionExpressionVisitor"/> will, 
  /// by default, ignore this expression and visit its child expressions via the <see cref="Remotion.Linq.Parsing.ExpressionVisitor.VisitExtension"/> and 
  /// <see cref="VisitChildren"/> methods.
  /// </para>
  /// </remarks>
#endif
    internal sealed class PartialEvaluationExceptionExpression
#if !NET_3_5
        : Expression
#else
    : ExtensionExpression
#endif
    {
#if NET_3_5
    public const ExpressionType ExpressionType = (ExpressionType) 100004;
#endif

        public PartialEvaluationExceptionExpression(Exception exception, Expression evaluatedExpression)
#if NET_3_5
      : base (ArgumentUtility.CheckNotNull ("evaluatedExpression", evaluatedExpression).Type, ExpressionType)
#endif
        {
            ArgumentUtility.CheckNotNull("exception", exception);

            Exception = exception;
            EvaluatedExpression = evaluatedExpression;
        }

#if !NET_3_5
        public override Type Type => EvaluatedExpression.Type;

        public override ExpressionType NodeType => ExpressionType.Extension;
#endif

        public Exception Exception { get; }

        public Expression EvaluatedExpression { get; }

        public override bool CanReduce => true;

        public override Expression Reduce()
        {
            return EvaluatedExpression;
        }

        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            ArgumentUtility.CheckNotNull("visitor", visitor);

            var newEvaluatedExpression = visitor.Visit(EvaluatedExpression);
            if (newEvaluatedExpression != EvaluatedExpression)
                return new PartialEvaluationExceptionExpression(Exception, newEvaluatedExpression);
            return this;
        }

        protected override Expression Accept(ExpressionVisitor visitor)
        {
            ArgumentUtility.CheckNotNull("visitor", visitor);

            var specificVisitor = visitor as IPartialEvaluationExceptionExpressionVisitor;
            if (specificVisitor != null)
                return specificVisitor.VisitPartialEvaluationException(this);
            return base.Accept(visitor);
        }

        public override string ToString()
        {
            return string.Format(
                @"PartialEvalException ({0} (""{1}""), {2})",
                Exception.GetType().Name,
                Exception.Message,
                EvaluatedExpression.BuildString());
        }
    }
}