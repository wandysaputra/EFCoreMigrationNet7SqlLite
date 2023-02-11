using EFCoreMigrationNet7SqlLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationNet7SqlLite.DbContexts;

public class BooksContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    public BooksContext(DbContextOptions<BooksContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new(Guid.Parse("e97cd87c-d2f9-4664-aa38-632fad458171"), "George", "RR Martin")
            , new(Guid.Parse("24bda992-eecc-4d01-adcb-0785283ac830"), "Stephen", "Fry")
            , new(Guid.Parse("29d414cc-73a7-415d-aa47-d881d50eef7d"), "James", "Elroy")
            , new(Guid.Parse("04b0fee0-1720-454f-b4cd-a60491df7e15"), "Douglas", "Adams")
        );

        modelBuilder.Entity<Book>().HasData(
            new(Guid.Parse("978567bf-0099-4b83-bf93-bafc6cb4222f"), Guid.Parse("e97cd87c-d2f9-4664-aa38-632fad458171"),
                "The Winds of Winter", "The book that seems impossible to write")
            , new(Guid.Parse("88116D67-167C-4271-893E-FCF3589A3DB2"),
                Guid.Parse("e97cd87c-d2f9-4664-aa38-632fad458171"), "Mythos",
                "The Greek myths are amongst the best stories ever told")
            , new(Guid.Parse("9ca0a641-b6eb-43ea-95c3-b12e6a339483"),
                Guid.Parse("24bda992-eecc-4d01-adcb-0785283ac830"), "A Game of Thrones",
                "A Game of Thrones is the first novel in A Song of Ice and Fire")
            , new(Guid.Parse("7e54e12f-1834-49a4-b4d6-05d62c397732"),
                Guid.Parse("29d414cc-73a7-415d-aa47-d881d50eef7d"), "American Tabloid", "a 1995 novel by James Ellroy")
            , new(Guid.Parse("d0d4b0a1-9fd9-47d9-9eac-4903ed444889"), Guid.Parse("04b0fee0-1720-454f-b4cd-a60491df7e15"), "The Hitchhiker's Guide to the Galaxy", "The Hitchicker's Guide to the Galaxy")
        );
        
        
        
        base.OnModelCreating(modelBuilder);
    }
}