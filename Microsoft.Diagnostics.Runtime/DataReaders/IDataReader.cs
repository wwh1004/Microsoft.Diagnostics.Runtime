// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.Diagnostics.Runtime {
	/// <summary>
	/// An interface for reading data out of the target process.
	/// </summary>
	internal interface IDataReader : IMemoryReader {
		/// <summary>
		/// The name of the target.  This should be a meaningful moniker such as the pid of the target
		/// process or the path to the dump being read.  This is primarily used when debugging to see
		/// what DataTarget is inspecting.
		/// </summary>
		string DisplayName { get; }

		/// <summary>
		/// Gets a value indicating whether this data reader is safe to use in parallel from multiple threads.
		/// </summary>
		bool IsThreadSafe { get; }

		/// <summary>
		/// Gets the architecture of the target.
		/// </summary>
		/// <returns>The architecture of the target.</returns>
		Architecture Architecture { get; }

		/// <summary>
		/// Gets the process ID of the DataTarget.
		/// </summary>
		int ProcessId { get; }

		/// <summary>
		/// Enumerates modules in the target process.
		/// </summary>
		/// <returns>An enumerable of the modules in the target process.</returns>
		IEnumerable<ModuleInfo> EnumerateModules();

		/// <summary>
		/// Returns the BuildId of a native Elf file.
		/// </summary>
		/// <param name="baseAddress"></param>
		/// <returns></returns>
		byte[] GetBuildId(ulong baseAddress);

		/// <summary>
		/// Gets the version information for a given module (given by the base address of the module).
		/// </summary>
		/// <param name="baseAddress">The base address of the module to look up.</param>
		/// <param name="version">The version info for the given module.</param>
		bool GetVersionInfo(ulong baseAddress, out Version version);

		/// <summary>
		/// Gets the thread context for the given thread.
		/// </summary>
		/// <param name="threadID">The OS thread ID to read the context from.</param>
		/// <param name="contextFlags">The requested context flags, or 0 for default flags.</param>
		/// <param name="context">A span to write the context to.</param>
		/// <param name="contextSize">The size of context</param>
		bool GetThreadContext(uint threadID, uint contextFlags, ref byte context, uint contextSize);

		/// <summary>
		/// Informs the data reader that the user has requested all data be flushed.
		/// </summary>
		void FlushCachedData();
	}
}
