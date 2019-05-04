# Uni Android Intent

adb shell am start で Android アプリを起動した時に指定された引数を解析する機能

[![](https://img.shields.io/github/release/baba-s/uni-android-intent.svg?label=latest%20version)](https://github.com/baba-s/uni-android-intent/releases)
[![](https://img.shields.io/github/release-date/baba-s/uni-android-intent.svg)](https://github.com/baba-s/uni-android-intent/releases)
![](https://img.shields.io/badge/Unity-2018.3%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x-orange.svg)
[![](https://img.shields.io/github/license/baba-s/uni-android-intent.svg)](https://github.com/baba-s/uni-android-intent/blob/master/LICENSE)

## バージョン

- Unity 2018.3.11f1

## 使用例

```cs
adb shell am start ^
    -n com.baba_s.uniandroidintent/com.unity3d.player.UnityPlayerActivity ^
    --ei i 123 ^
    --el l 456 ^
    -e s ABC ^
    --ez b true ^
    --eia ia 111,223,343 ^
    --ela la 444,555,666 ^
    --esa sa AAA,BBB,CCC
```

adb shell am start を使用して、引数付きで Android アプリを起動した場合に  

```cs
// int 型の値を取得
Debug.Log( UniAndroidIntent.GetInt( "i" ) );

// long 型の値を取得
Debug.Log( UniAndroidIntent.GetLong( "l" ) );

// string 型の値を取得
Debug.Log( UniAndroidIntent.GetString( "s" ) );

// bool 型の値を取得
Debug.Log( UniAndroidIntent.GetBool( "b" ) );

// int 型の配列を取得
foreach ( var n in UniAndroidIntent.GetIntArray( "ia" ) )
{
    Debug.Log( n );
}

// long 型の配列を取得
foreach ( var n in UniAndroidIntent.GetLongArray( "la" ) )
{
    Debug.Log( n );
}

// string 型の配列を取得
foreach ( var n in UniAndroidIntent.GetStringArray( "sa" ) )
{
    Debug.Log( n );
}
```

このようなコードで引数を解析して使用できます  

![](https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20190502/20190502180332.png)

## adb shell am start の引数の指定方法

|型|指定方法|
|:--|:--|
|int|--ei 【引数名】 【引数の値】|
|long|--el 【引数名】 【引数の値】|
|string|-e 【引数名】 【引数の値】|
|bool|--ez 【引数名】 【引数の値】|
|int の配列|--eia 【引数名】 【配列の値（カンマ区切り）】|
|long の配列|--ela 【引数名】 【配列の値（カンマ区切り）】|
|string の配列|--esa 【引数名】 【配列の値（カンマ区切り）】|

## 用途

- 例えば、Jenkins などでアプリを自動ビルドした後に  
そのアプリを Android 端末に自動でインストールして  
さらに自動でエージングテストを実行することで、  
ビルドしたアプリが正常に動作するかどうか確認する、といった場面で使用できます  

## 参考サイト様

- https://developer.android.com/reference/android/content/Intent  
