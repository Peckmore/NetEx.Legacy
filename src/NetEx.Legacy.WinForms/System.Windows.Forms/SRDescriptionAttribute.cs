﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;

namespace System.Windows.Forms
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SRDescriptionAttribute : DescriptionAttribute
    {
        private bool replaced;

        public override string Description
        {
            get
            {
                if (!replaced)
                {
                    replaced = true;
                    // LEGACY_SHIM
                    // base.DescriptionValue = SR.GetResourceString(base.Description);
                    base.DescriptionValue = SRShim.GetResourceString(base.Description);
                }
                return base.Description;
            }
        }

        public SRDescriptionAttribute(string description) : base(description)
        {
        }
    }
}
