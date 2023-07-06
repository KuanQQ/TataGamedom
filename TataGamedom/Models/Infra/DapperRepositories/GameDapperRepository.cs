﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.Games;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Interfaces;
using Dapper;
using TataGamedom.Models.ViewModels.Games;
using System.Reflection;
using System.Diagnostics;

namespace TataGamedom.Models.Infra.DapperRepositories
{
	public class GameDapperRepository : IGameRepository
	{
		private string _connStr;
		private AppDbContext db = new AppDbContext();

		public GameDapperRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		}

		public bool Create(GameCreateDto dto)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO Games(ChiName,EngName,Description,IsRestrict
  ,GameCoverImg,CreatedTime,CreatedBackendMemberId)
  VALUES(@ChiName,@EngName,@Description,@IsRestrict
  ,@GameCoverImg,@CreatedTime,@CreatedBackendMemberId)";

				var rowAffected = conn.Execute(sql, dto);
				return rowAffected > 0;
			}
		}

		public List<GameClassificationsCode> GetGameClassifications()
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT * FROM GameClassificationsCodes";
				return conn.Query<GameClassificationsCode>(sql).ToList();
			}
		}

		public GameEditVM GetGameById(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT ChiName, EngName, STRING_AGG(GCC.Id, ',') AS SelectedGameClassificationString,Description, G.IsRestrict AS IsRestrict,BM.Name AS ModifiedBackendMemberName, G.ModifiedTime AS ModifiedTime
FROM Games AS G
LEFT JOIN GameClassificationGames AS GCG ON GCG.GameId = G.Id
LEFT JOIN GameClassificationsCodes AS GCC ON GCC.Id = GCG.GameClassificationId
LEFT JOIN BackendMembers AS BM ON BM.Id = G.ModifiedBackendMemberId
WHERE G.Id = @Id
GROUP BY G.Id, G.ChiName,G.EngName,G.Description, G.IsRestrict, G.ModifiedTime, BM.Name
";
				return conn.QueryFirstOrDefault<GameEditVM>(sql, new { Id = id });
			}
		}

		public GameCreateDto GetGameByName(string chi, string eng)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT * FROM Games WHERE ChiName=@ChiName OR EngName=@EngName";
				return conn.QueryFirstOrDefault<GameCreateDto>(sql, new { ChiName = chi, EngName = eng });
			}
		}

		public IEnumerable<GameIndexDto> Search()
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT G.Id AS Id, G.ChiName AS ChiName, STRING_AGG(GCC.Name, ' , ') AS Classification, G.IsRestrict AS IsRestrict,BM.Name AS CreatedBackendMemberName, CONVERT(date,G.CreatedTime) AS CreatedTime
FROM Games AS G
LEFT JOIN GameClassificationGames AS GCG ON GCG.GameId = G.Id
LEFT JOIN GameClassificationsCodes AS GCC ON GCC.Id = GCG.GameClassificationId
JOIN BackendMembers AS BM ON BM.Id = G.CreatedBackendMemberId
GROUP BY G.Id, G.ChiName, G.IsRestrict, G.CreatedTime, BM.Name";

				return conn.Query<GameIndexDto>(sql);
			};
		}

		public bool UpddateGame(GameEditDto dto)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"UPDATE Games SET ChiName = @ChiName,EngName=@EngName,Description=@Description,IsRestrict=@IsRestrict,ModifiedTime=@ModifiedTime,ModifiedBackendMemberId=@ModifiedBackendMemberId WHERE Id=@id";
				var rowAffected = conn.Execute(sql, dto);
				return rowAffected > 0;
			}
		}

		public GameEditCoverImgDto GetGameById2(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT * FROM Games WHERE Id=@id";
				return conn.QueryFirstOrDefault<GameEditCoverImgDto>(sql, new { Id = id });
			}
		}

		public bool EditGameCover(GameEditCoverImgDto dto)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"UPDATE Games SET GameCoverImg = @GameCoverImg,ModifiedTime=@ModifiedTime, ModifiedBackendMemberId=@ModifiedBackendMemberId  WHERE Id = @Id";
				var rowAffected = conn.Execute(sql, dto);
				return rowAffected > 0;
			}
		}

		public Game GetGameByName2(string name)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT * FROM Games WHERE ChiName=@ChiName";
				return conn.QueryFirstOrDefault<Game>(sql, new { ChiName = name });
			}
		}

		public bool CreateBoard(Game game)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO Boards(Name , GameId, BoardHeaderCoverImg, BoardAbout,CreatedTime, CreatedBackendMemberId) VALUES(@Name , @GameId, @BoardHeaderCoverImg, @BoardAbout, @CreatedTime, @CreatedBackendMemberId);";
				var rowAffected = conn.Execute(sql, new { Name = game.ChiName, GameId = game.Id, BoardHeaderCoverImg = game.GameCoverImg, BoardAbout=game.Description,CreatedTime = game.CreatedTime, CreatedBackendMemberId = game.CreatedBackendMemberId });
				return rowAffected > 0;
			}
		}

		public bool CreateClassification(Game game, int selectedGameClassification)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO GameClassificationGames(GameId, GameClassificationId) VALUES(@GameId, @GameClassificationId);";
				var rowAffected = conn.Execute(sql, new { GameId = game.Id, GameClassificationId = selectedGameClassification });
				return rowAffected > 0;
			}
		}
		public bool UpdateClassification(GameEditVM game, int selectedGameClassification)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO GameClassificationGames(GameId, GameClassificationId) VALUES(@GameId, @GameClassificationId);";
				var rowAffected = conn.Execute(sql, new { GameId = game.Id, GameClassificationId = selectedGameClassification });
				return rowAffected > 0;
			}
		}
		public List<int> GetGameClassificationsByGameId(int gameId)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT GameClassificationId FROM GameClassificationGames WHERE GameId = @GameId;";
				return conn.Query<int>(sql, new { GameId = gameId }).ToList();
			}
		}

		public IEnumerable<GameEditVM> GetGameClassificationGames(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT * FROM GameClassificationGames WHERE GameId = @Id";
				return conn.Query<GameEditVM>(sql, new { Id = id });
			}
		}

		public bool DeleteGameClassificationGames(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"DELETE GameClassificationGames WHERE GameId= @Id";
				var rowAffected = conn.Execute(sql, new { Id = id });
				return rowAffected > 0;
			}
		}

		//用來改成通用的
		public Game GetGameByIdForAddProduct(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT*FROM Games WHERE Id = @Id;";
				return conn.QueryFirstOrDefault<Game>(sql, new { Id = id });
			}
		}

		public bool CreateProduct(Product product)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO Products ([Index], GameId, IsVirtual, Price, GamePlatformId, SystemRequire, ProductStatusId, SaleDate, CreatedBackendMemberId, CreatedTime)
VALUES(@Index, @GameId, @IsVirtual, @Price, @GamePlatformId, @SystemRequire, @ProductStatusId, @SaleDate, @CreatedBackendMemberId, @CreatedTime)";
				var rowAffected = conn.Execute(sql, new { Index = product.Index, GameId = product.GameId, IsVirtual = product.IsVirtual, Price = product.Price, GamePlatformId = product.GamePlatformId, SystemRequire = product.SystemRequire, ProductStatusId = product.ProductStatusId, SaleDate = product.SaleDate, CreatedBackendMemberId = product.CreatedBackendMemberId, CreatedTime = product.CreatedTime });
				return rowAffected > 0;
			}
		}

		public bool CreateProductImg(ProductImage productImage)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO ProductImages(ProductId,Image)VALUES(@ProductId,@Image)";
				var rowAffected = conn.Execute(sql, productImage);
				return rowAffected > 0;
			}
		}
		public bool IsDuplicateChineseName(int gameId, string chiName)
		{
			return db.Games.Any(g => g.Id != gameId && g.ChiName == chiName);
		}

		public bool IsDuplicateEnglishName(int gameId, string engName)
		{
			return db.Games.Any(g => g.Id != gameId && g.EngName == engName);
		}
	}
}