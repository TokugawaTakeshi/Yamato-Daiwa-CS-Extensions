# 「Yamato Daiwa CS(harp) extensions」ライブラリの日本語化・日本関連機能

<!-- ⚠ 「NuGet Gallery」は「dl」に対応されていないので使うのは意味ない -->

## 機能

### `JapanesePhoneNumber`クラス

日本電話番号関連処理のに使われる。
完全に静的クラスである。

#### メソッド
##### `Format`

```csharp
string Format(string phoneNumber)
```

単一の引数で渡され、日本の電話番号に該当している数字と任意なハイフンから成り立っていると期待されている文字列をフォーマットする。
内容はは、正しくない位置からハイフンを取り除き、正しい位置にハイフンを入れる事。

##### `IsValid`

```csharp
bool IsValid(string potentialJapanesePhoneNumber)
```
単一の引数で渡され、数字と任意なハイフンから成り立っていると期待されている文字列が日本の電話番号に該当しているか、確認する。
該当している場合`true`を返し、さもなくば`false`を返す。


#### 定数
##### `DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH`

| Key　 | Value　 |
|------|--------|
| 型    | `byte` |
| 値    | `4`    |


#### 読み込み専用静的フィルド
##### `VALID_PATTERN__WITHOUT_DASHES`

| Key　 | Value　        |
|------|---------------|
| 型    | `Regex`       |
| 値    | `^\d{10,11}$` |


## 日本語化
### データモキング
#### `MockGatewayHelperJapaneseLocalization`

**MockGatewayHelper**クラス専用日本語化。

```csharp
MockGatewayHelper.Localization = new MockGatewayHelperJapaneseLocalization();
```