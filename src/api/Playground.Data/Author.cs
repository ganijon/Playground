﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
