// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
using System.Collections.Generic;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Scriban.Runtime.Accessors
{
    public class StringAccessor : IListAccessor, IObjectAccessor
    {
        public static StringAccessor Default = new StringAccessor();

        private StringAccessor()
        {
        }

        public int GetLength(TemplateContext context, SourceSpan span, object target)
        {
            return ((string)target).Length;
        }

        public object GetValue(TemplateContext context, SourceSpan span, object target, int index)
        {
            return ((string)target)[index].ToString();
        }

        public void SetValue(TemplateContext context, SourceSpan span, object target, int index, object value)
        {
            throw new ScriptRuntimeException(span, "Cannot replace a character in a string");
        }

        public int GetMemberCount(TemplateContext context, SourceSpan span, object target)
        {
            // size
            return 1;
        }

        public IEnumerable<string> GetMembers(TemplateContext context, SourceSpan span, object target)
        {
            yield return "size";
        }

        public bool HasMember(TemplateContext context, SourceSpan span, object target, string member)
        {
            return member == "size";
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, object target, string member, out object value)
        {
            if (member == "size")
            {
                value = GetLength(context, span, target);
                return true;
            }
            value = null;
            return false;
        }

        public bool TrySetValue(TemplateContext context, SourceSpan span, object target, string member, object value)
        {
            return false;
        }
    }
}