﻿namespace Msi.Utilities.Filter
{
    public class PaginationUtilitiesOptions
    {

        public PagingOptions PagingOptions { get; set; }

        public static PaginationUtilitiesOptions DefaultOptions
        {
            get
            {
                return new PaginationUtilitiesOptions
                {
                    PagingOptions = new PagingOptions
                    {
                        Limit = 20,
                        Offset = 0
                    }
                };
            }
        }

    }
}
