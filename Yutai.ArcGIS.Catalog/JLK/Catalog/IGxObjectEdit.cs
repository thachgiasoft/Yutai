﻿namespace JLK.Catalog
{
    using System;

    public interface IGxObjectEdit
    {
        bool CanCopy();
        bool CanDelete();
        bool CanRename();
        void Delete();
        void EditProperties(int int_0);
        void Rename(string string_0);
    }
}

