using System.Collections.Generic;
using Player.Application.Products.Queries.GetProductsFile;

namespace Player.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
