# comic-backend ローカル開発手順

## 前提
- Docker Desktop を起動しておく
- このリポジトリを clone した **comic-backend フォルダ**で作業する

---

## 起動〜確認〜停止（上から順に実行）

### 1. DB（PostgreSQL）起動  
**実行場所：comic-backend フォルダ**
```bash
docker compose -f docker/docker-compose.yml up -d
```

### 2. DB起動確認
```bash
docker ps
```
`comic-postgres`が`Up`になっていればOK。

### 3. DB疎通確認
```bash
docker exec -it comic-postgres psql -U comic -d comicdb -c "select 1;"
```
`1`が返ればOK。



### 4. API起動
**実行場所：src/Comic.Apiフォルダ**
```bash
dotnet run
```
エラーなく起動すればOK。


### 5. API確認（Swagger）
`https://localhost:7069/swagger`


**認証付きAPIの確認**
1. POST /auth/dev-token を実行して accessToken を取得
2. Swagger 右上 Authorize にトークンを貼り付け（Bearer不要）
3. GET /me が 200（未設定時は 401）




### 6. API停止
起動中のターミナルで`Ctrl + C`

### 7. DB停止
**実行場所：comic-backend フォルダ**
```bash
docker compose -f docker/docker-compose.yml down
```



## EF Core Migrations（DBスキーマ変更）

### 前提
- Postgres（Docker）が起動していること
- `Comic.Api` の接続文字列が Postgres を指していること

### マイグレーション作成
**実行場所：comic-backend フォルダ**
(`Comic.Api.csproj` があるフォルダで実行します。)

```bash
dotnet ef migrations add <MigrationName>
```

### DBへ反映（update database）
```bash
dotnet ef database update
```

### 直前のマイグレーションを取り消す
```bash
dotnet ef migrations remove
```

### マイグレーション一覧を見る
```bash
dotnet ef migrations list
```
