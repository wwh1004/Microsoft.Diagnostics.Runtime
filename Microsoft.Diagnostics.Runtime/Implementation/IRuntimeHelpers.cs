// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Diagnostics.Runtime.Implementation {
	internal interface IRuntimeHelpers : IDisposable {
		IDataReader DataReader { get; }
		ClrAppDomain[] GetAppDomains(ClrRuntime runtime, out ClrAppDomain? system, out ClrAppDomain? shared);
		void FlushCachedData();
	}
}
