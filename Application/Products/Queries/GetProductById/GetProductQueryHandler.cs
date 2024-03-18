using Application.Products.Queries.GetWebinarById;
using Domain.Exceptions;
using System.Data;

namespace Application.Products.Queries.GetProductById;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IDbcinnection _dbConnection;
    public GetProductQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<ProductResponse> Handler(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM ""Products"" WHERE ""Id"" = @ProductId";

        var product = await _dbConnection.QueryFirstorDefaultAsync<ProductResponse>(
            sql, 
            new { request.ProductId});
        
        if(product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        return product;
    }

}
