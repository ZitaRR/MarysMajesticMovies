using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarysMajesticMovies.Migrations
{
    public partial class AddedDbContextToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImdbId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    RunTime = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Actors = table.Column<string>(nullable: false),
                    Plot = table.Column<string>(nullable: false),
                    ImdbRating = table.Column<double>(nullable: false),
                    PosterUrl = table.Column<string>(nullable: false),
                    TrailerUrl = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    InStock = table.Column<int>(nullable: false),
                    AddedToStoreDate = table.Column<DateTime>(nullable: false),
                    NoOfOrders = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderLine = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    PricePerQty = table.Column<double>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "AddedToStoreDate", "Director", "Genre", "ImdbId", "ImdbRating", "InStock", "NoOfOrders", "Plot", "PosterUrl", "Price", "RunTime", "Title", "TrailerUrl", "Year" },
                values: new object[,]
                {
                    { 1, "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page", new DateTime(2020, 5, 29, 14, 20, 18, 525, DateTimeKind.Local).AddTicks(8454), "Christopher Nolan", "Action, Adventure, Sci-Fi", "tt1375666", 8.8000000000000007, 7, 0, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg", 149.0, "148", "Inception", "https://www.youtube.com/watch?v=YoHD9XEInc0", 2010 },
                    { 29, "Björn A. Ling, Kjell Bergqvist, Tuva Novotny", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6324), "Ulf Malmros", "Comedy, Drama, Romance", "tt1359421", 5.9000000000000004, 3, 0, "When the factory in Molkom shuts down, Robin leaves his beloved hometown to try his luck in Stockholm as a wedding photographer. This experience changes not merely his outlook on life but also his hairstyle.", "https://m.media-amazon.com/images/M/MV5BYzgxMTU3YjEtZjQ2NS00MTA5LTk3ZTItMzkyODI3NTMzYTM5XkEyXkFqcGdeQXVyMTQzMjU1NjE@._V1_.jpg", 79.0, "113", "Bröllopsfotografen", "https://www.youtube.com/watch?v=j2Ai6zAzkOQ", 2009 },
                    { 28, "Rumi Hiiragi, Miyu Irino, Mari Natsuki", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6320), "Hayao Miyazaki", "Animation, Adventure, Family", "tt0245429", 8.5999999999999996, 18, 0, "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.", "https://m.media-amazon.com/images/M/MV5BMjlmZmI5MDctNDE2YS00YWE0LWE5ZWItZDBhYWQ0NTcxNWRhXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,674,1000_AL_.jpg", 79.0, "125", "Spirited Away", "https://www.youtube.com/watch?v=qCgon52mp2M", 2001 },
                    { 27, "Chieko Baishô, Takuya Kimura, Tatsuya Gashûin", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6316), "Hayao Miyazaki", "Animation, Adventure, Family", "tt0347149", 8.1999999999999993, 25, 0, "When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.", "https://m.media-amazon.com/images/M/MV5BNmM4YTFmMmItMGE3Yy00MmRkLTlmZGEtMzZlOTQzYjk3MzA2XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,666,1000_AL_.jpg", 79.0, "119", "Howl's Moving Castle", "https://www.youtube.com/watch?v=yUZCo0oWt4o", 2004 },
                    { 26, "Hitoshi Takagi, Noriko Hidaka, Chika Sakamoto", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6312), "Hayao Miyazaki", "Animation, Family, Fantasy", "tt0096283", 8.1999999999999993, 28, 0, "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.", "https://m.media-amazon.com/images/M/MV5BYzJjMTYyMjQtZDI0My00ZjE2LTkyNGYtOTllNGQxNDMyZjE0XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", 79.0, "86", "My Neighbour Totoro", "https://www.youtube.com/watch?v=92a7Hj0ijLs", 1988 },
                    { 25, "Daniel Radcliffe, Rupert Grint, Emma Watson", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6309), "Chris Columbus", "Adventure, Family, Fantasy", "tt0241527", 7.5999999999999996, 14, 0, "An orphaned boy enrolls in a school of wizardry, where he learns the truth about himself, his family and the terrible evil that haunts the magical world. ", "https://m.media-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_.jpg", 109.0, "152", "Harry Potter and the Philosophers Stone", "https://www.youtube.com/watch?v=VyHV0BRtdxo", 2001 },
                    { 24, "Chris Hemsworth, Tom Hiddleston, Cate Blanchett", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6304), "Taika Waititi", "Action, Adventure, Comedy", "tt3501632", 7.9000000000000004, 39, 0, "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela. ", "https://m.media-amazon.com/images/M/MV5BMjMyNDkzMzI1OF5BMl5BanBnXkFtZTgwODcxODg5MjI@._V1_SY1000_CR0,0,674,1000_AL_.jpg", 179.0, "130", "Thor Ragnarök", "https://www.youtube.com/watch?v=v7MGUNV8MxU", 2017 },
                    { 23, "Robert Downey Jr., Chris Evans, Scarlett Johansson", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6300), "Joss Whedon", "Action, Adventure, Sci-Fi", "tt0848228", 8.0, 21, 0, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity. ", "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,675,1000_AL_.jpg", 129.0, "143", "The Avengers", "https://www.youtube.com/watch?v=hIR8Ar-Z4hw", 2012 },
                    { 22, "Jesse Eisenberg, Mark Ruffalo, Woody Harrelson", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6296), "Louis Leterrier", "Crime, Mystery, Thriller", "tt1670345", 7.2999999999999998, 18, 0, "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money. ", "https://m.media-amazon.com/images/M/MV5BMTY0NDY3MDMxN15BMl5BanBnXkFtZTcwOTM5NzMzOQ@@._V1_SY1000_CR0,0,642,1000_AL_.jpg", 99.0, "115", "Now You See Me", "https://www.youtube.com/watch?v=4OtM9j2lcUA", 2013 },
                    { 21, "Kang-ho Son, Sun-Kyun Lee, Yeo-Yeong Jo", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6292), "Bong Joon Ho", "Comedy, Drama, Thriller", "tt6751668", 8.5999999999999996, 30, 0, "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan. ", "https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_SY1000_CR0,0,674,1000_AL_.jpg", 199.0, "132", "Parasite", "https://www.youtube.com/watch?v=5xH0HfJHsaY", 2019 },
                    { 20, "Patrick Wilson, Vera Farmiga, Ron Livingston", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6289), "James Wan", "Horror, Mystery, Thriller", "tt1457767", 7.5, 22, 0, "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.", "https://m.media-amazon.com/images/M/MV5BMTM3NjA1NDMyMV5BMl5BanBnXkFtZTcwMDQzNDMzOQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg", 149.0, "112", "The Conjuring", "https://www.youtube.com/watch?v=k10ETZ41q5o", 2013 },
                    { 19, "Ward Horton, Annabelle Wallis, Alfre Woodard", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6285), "John R. Leonetti", "Horror, Mystery, Thriller", "tt3322940", 5.4000000000000004, 16, 0, "A couple begins to experience terrifying supernatural occurrences involving a vintage doll shortly after their home is invaded by satanic cultists.", "https://m.media-amazon.com/images/M/MV5BOTQwZmQyYzEtODk5ZC00OTY3LWExMjAtYzRjNWFhNGM3MzBlXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SY1000_CR0,0,674,1000_AL_.jpg", 129.0, "109", "Annabelle", "https://www.youtube.com/watch?v=paFgQNPGlsg", 2014 },
                    { 18, "Elisabeth Moss, Oliver Jackson-Cohen, Harriet Dyer", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6280), "Leigh Whannell", "Horror, Mystery, Sci-Fi", "tt1051906", 7.0999999999999996, 35, 0, "When Cecilia's abusive ex takes his own life and leaves her his fortune, she suspects his death was a hoax. As a series of coincidences turn lethal, Cecilia works to prove that she is being hunted by someone nobody can see.", "https://m.media-amazon.com/images/M/MV5BZjFhM2I4ZDYtZWMwNC00NTYzLWE3MDgtNjgxYmM3ZWMxYmVmXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,631,1000_AL_.jpg", 229.0, "124", "The Invisible Man", "https://www.youtube.com/watch?v=Pso0Aj_cTh0", 2020 },
                    { 17, "Russel Crowe, Joaquin Phoenix, Connie Nielsen", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6276), "Ridley Scott", "Action, Drama, Adventure", "tt0172495", 8.5, 12, 0, "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", "https://m.media-amazon.com/images/M/MV5BMDliMmNhNDEtODUyOS00MjNlLTgxODEtN2U3NzIxMGVkZTA1L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,675,1000_AL_.jpg", 109.0, "155", "Gladiator", "https://www.youtube.com/watch?v=Q-b7B8tOAQU", 2000 },
                    { 30, "Tuva Novotny, Jonas Rimeika, Björn A. Ling", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6328), "Ulf Malmros", "Comedy, Crime, Mystery", "tt0323998", 6.9000000000000004, 5, 0, "A young man returns to his hometown to look for his missing sister.", "https://m.media-amazon.com/images/M/MV5BMTMxMTEwNzI3Nl5BMl5BanBnXkFtZTcwMzQ1ODkyMQ@@._V1_.jpg", 79.0, "117", "Smala Sussie", "https://www.youtube.com/watch?v=Q8Drrm6Mlco", 2003 },
                    { 16, "Brad Pitt, Edward Norton, Helena Bonham Carter", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6273), "David Fincher", "Drama", "tt0137523", 8.8000000000000007, 7, 0, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more. ", "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,666,1000_AL_.jpg", 119.0, "139", "Fight Club", "https://www.youtube.com/watch?v=qtRKdVHc-cE", 1999 },
                    { 14, "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6264), "James Cameron", "Action, Sci-Fi", "tt0088247", 8.0, 17, 0, "In 1984, a human soldier is tasked to stop an indestructible cyborg killing machine, both sent from 2029, from executing a young woman, whose unborn son is the key to humanity's future salvation.", "https://m.media-amazon.com/images/M/MV5BYTViNzMxZjEtZGEwNy00MDNiLWIzNGQtZDY2MjQ1OWViZjFmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,666,1000_AL_.jpg", 89.0, "107", "Terminator", "https://www.youtube.com/watch?v=k64P4l2Wmeg", 1984 },
                    { 13, "Elijah Wood, Viggo Mortensen, Ian McKellen", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6260), "Peter Jackson", "Adventure, Drama, Fantasy", "tt0167260", 8.9000000000000004, 15, 0, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,675,1000_AL_.jpg", 129.0, "201", "The Lord of the Rings: The Return of the King", "https://www.youtube.com/watch?v=r5X-hFf6Bwo", 2003 },
                    { 12, "Elijah Wood, Ian McKellen, Viggo Mortensen", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6256), "Peter Jackson", "Adventure, Drama, Fantasy", "tt0167261", 8.6999999999999993, 22, 0, "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg", 129.0, "179", "The Lord of the Rings: The Two Towers", "https://www.youtube.com/watch?v=hYcw5ksV8YQ", 2002 },
                    { 11, "Jean Reno, Gary Oldman, Natalie Portman", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6252), "Luc Besson", "Action, Crime, Drama", "tt0110413", 8.5, 11, 0, "Mathilda, a 12-year-old girl, is reluctantly taken in by Léon, a professional assassin, after her family is murdered. An unusual relationship forms as she becomes his protégée and learns the assassin's trade.", "https://m.media-amazon.com/images/M/MV5BZDAwYTlhMDEtNTg0OS00NDY2LWJjOWItNWY3YTZkM2UxYzUzXkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_SY1000_CR0,0,710,1000_AL_.jpg", 99.0, "110", "Leon", "https://www.youtube.com/watch?v=jawVxq1Iyl0", 1994 },
                    { 10, "David Sandberg, Jorma Taccone, Steven Chew", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6247), "David Sandberg", "Short, Action, Comedy", "tt3472226", 8.0, 73, 0, "In 1985, Kung Fury, the toughest martial artist cop in Miami, goes back in time to kill the worst criminal of all time - Kung Führer, a.k.a. Adolf Hitler.", "https://m.media-amazon.com/images/M/MV5BMjQwMjU2ODU5NF5BMl5BanBnXkFtZTgwNTU1NjM4NTE@._V1_SY999_CR0,0,702,999_AL_.jpg", 229.0, "31", "Kung Fury", "https://www.youtube.com/watch?v=89AxvewTS90", 2015 },
                    { 9, "Liam Neeson, Ralph Fiennes, Ben Kingsley", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6243), "Steven Spielberg", "Biography, Drama, History", "tt0108052", 8.9000000000000004, 13, 0, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,666,1000_AL_.jpg", 129.0, "195", "Schindler's List", "https://www.youtube.com/watch?v=gG22XNhtnoY", 1993 },
                    { 8, "Robin Williams, Robert Sean Leonard, Ethan Hawke", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6238), "Peter Weir", "Comedy, Drama", "tt0097165", 8.0999999999999996, 5, 0, "English teacher John Keating inspires his students to look at poetry with a different perspective of authentic knowledge and feelings.", "https://m.media-amazon.com/images/M/MV5BOGYwYWNjMzgtNGU4ZC00NWQ2LWEwZjUtMzE1Zjc3NjY3YTU1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,677,1000_AL_.jpg", 79.0, "128", "Dead Poets Society", "https://www.youtube.com/watch?v=ye4KFyWu2do", 1989 },
                    { 7, "Tatsuya Fujiwara, Aki Maeda, Tarô Yamamoto", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6234), "Kinji Fukusaku", "Adventure, Drama, Sci-Fi", "tt0266308", 7.5999999999999996, 11, 0, "In the future, the Japanese government captures a class of ninth-grade students and forces them to kill each other under the revolutionary 'Battle Royale' act.", "https://m.media-amazon.com/images/M/MV5BMDc2MGYwYzAtNzE2Yi00YmU3LTkxMDUtODk2YjhiNDM5NDIyXkEyXkFqcGdeQXVyMTEwNDU1MzEy._V1_SY1000_CR0,0,666,1000_AL_.jpg", 159.0, "116", "Battle Royale", "https://www.youtube.com/watch?v=N0p1t-dC7Ko", 2000 },
                    { 6, "Hugo Weaving, Natalie Portman, Rupert Graves", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6229), "James McTeigue", "Action, Drama, Sci-Fi", "tt0434409", 8.1999999999999993, 19, 0, "In a future British tyranny, a shadowy freedom fighter, known only by the alias of 'V', plots to overthrow it with the help of a young woman.", "https://m.media-amazon.com/images/M/MV5BOTI5ODc3NzExNV5BMl5BanBnXkFtZTcwNzYxNzQzMw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg", 139.0, "132", "V for Vendetta", "https://www.youtube.com/watch?v=lSA7mAHolAw", 2005 },
                    { 5, "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6175), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", 8.6999999999999993, 18, 0, "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg", 79.0, "136", "The Matrix", "https://www.youtube.com/watch?v=m8e-FF8MsqU", 1999 },
                    { 4, "Elijah Wood, Ian McKellen, Orlando Bloom", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6171), "Peter Jackson", "Action, Aventure, Drama", "tt0120737", 8.8000000000000007, 5, 0, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SY999_CR0,0,673,999_AL_.jpg", 129.0, "178", "The Lord of the Rings: The Fellowship of the Ring", "https://www.youtube.com/watch?v=V75dMMIW2B4", 2001 },
                    { 3, "Sam Neill, Laura Dern, Jeff Goldblum", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6164), "Steven Spielberg", "Action, Aventure, Sci-Fi", "tt0107290", 8.0999999999999996, 12, 0, "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park's cloned dinosaurs to run loose.", "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_.jpg", 129.0, "127", "Jurrasic Park", "https://www.youtube.com/watch?v=KdGO9tL2DQ4", 1993 },
                    { 2, "Helena Bergström, Rikard Wolff, Sven Wollter", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6119), "Colin Nutley", "Comedy, Drama", "tt0105916", 6.2999999999999998, 5, 0, "A rural village is divided when an extraordinary couple move into a mansion.", "https://m.media-amazon.com/images/M/MV5BNmE5ZjM3MDgtNmY5My00Y2JiLThmNDItZjU2NjIwNTYyNTdjXkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_.jpg", 99.0, "119", "Änglagård", "https://www.youtube.com/watch?v=NsvkwMTXzOI", 1992 },
                    { 15, "Scarlett Johansson, Morgan Freeman, Min-Sik Choi", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6269), "Luc Besson", "Action, Sci-Fi, Thriller", "tt2872732", 6.4000000000000004, 19, 0, "A woman, accidentally caught in a dark deal, turns the tables on her captors and transforms into a merciless warrior evolved beyond human logic. ", "https://m.media-amazon.com/images/M/MV5BODcxMzY3ODY1NF5BMl5BanBnXkFtZTgwNzg1NDY4MTE@._V1_SY1000_CR0,0,631,1000_AL_.jpg", 119.0, "89", "Lucy", "https://www.youtube.com/watch?v=bN7ksFEVO9U", 2014 },
                    { 31, "Tom Hardy, Charlize Theron, Nicholas Hoult", new DateTime(2020, 5, 29, 14, 20, 18, 528, DateTimeKind.Local).AddTicks(6332), "George Miller", "Action, Adventure, Sci-Fi", "tt1392190", 8.0999999999999996, 20, 0, "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners, a psychotic worshiper, and a drifter named Max.", "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", 159.0, "120", "Mad Max: Fury Road", "https://www.youtube.com/watch?v=hEJnMQG9ev8", 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_MovieId",
                table: "OrderRows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderRows");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
