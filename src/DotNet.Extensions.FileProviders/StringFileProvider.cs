// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Collections;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace DotNet.Extensions.FileProviders
{

    public class StringFileProvider : IFileProvider, IFileInfo, IDirectoryContents
    {
        string _inputContext;
        List<IFileInfo> list;
        public StringFileProvider(string inputContext)
        {
            _inputContext = inputContext;
            list = new List<IFileInfo>();
            list.Add(this);
        }

        // IFileInfo
        public bool Exists => true;

        public bool IsDirectory => false;

        public DateTimeOffset LastModified => DateTimeOffset.Now;

        public long Length => _inputContext.Length;

        public string Name => nameof(StringFileProvider);

        public string PhysicalPath => "";

        public Stream CreateReadStream()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(_inputContext));
        }

        // IFileProvider
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return this;
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return this;
        }
           
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IChangeToken IFileProvider.Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
