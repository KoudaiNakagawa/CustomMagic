# 説明

**CustomMagic**は見下ろし型の魔法で戦う2Dゲームです。
使用する魔法はプリセットの他に、SimpLangという言語を使用して作成できる**CustomMagic**があり、これは魔法の強力さに比例して**消費マナ**と**タメ時間**は増大します。
タメ時間中にスタンダメージを受けると、魔法はキャンセルされ、消費したマナと共に霧散します。

現時点で、1vs1の対人戦闘とボスvs1~4の協力戦闘を予定しています。ボスのビジュアル、使用魔法、行動パターンは、AIを活用することも検討しています。


# 関数ざっくり


魔法を構成する関数として、
* 挙動
* 範囲
* ダメージ
* 妨害/バフ

があります。例えば、

* 挙動:クリックした座標に素早く向かう
* 範囲:広め
* ダメージ:普通

といった基本的な魔法や、

* 挙動:比例誘導で敵にゆっくり向かう
* 範囲:狭め
* ダメージ:多め

といったビッグマナな魔法、あるいは、

* 挙動:自分に追従する
* 範囲:キャラクター1人分
* バフ:ダメージを軽減する

といったディフェンシブな魔法も作成できます。

---

# 関数詳細

## Movement(type, spead, lotation=0)
* type
    * int 0 ~ 2
    * ストレート (0)
    * 単純追尾誘導 (1)
    * 比例誘導 (2)
* spead
    * int 1 ~ 512
* lotation (進行方向から時計回りに回転します。オプション引数。)
    * int 0 ~ 360

```cost += (1+ type* 0.25)* (spead)* (lotation+1)```

## Area(radius, time, angle=360)
* radius
    * int 1 ~ 512
* time
    * int 1 ~ 512
* angle (進行方向から扇形の範囲を指定できます。オプション引数。) 
    * int 0 ~ 360 

```cost += rdius* time* (amgle+1)```


## Damage(physics, stun)
*  physics
    * int 0 ~ 512
* stun
    * int 0 ~ 512

```cost += (physics+1)* (stun+1)```


## Buff()

## Debuff()


## End(time=0)
* time
    * time 0 ~ 512

```cost += time```

---

# SimpLang-BNF

```
Str := Char+
    Lower := Regular[a-z]
    Upper := Regular[A-Z]

    Char := Lower | Upper

Int := PosNum | Zero | NegNum
    Zero := '0'
    NonZeroNums :=  ‘1’ | ‘2’ | ‘3’ | ‘4’ | ‘5’ | ‘6’ | ‘7’ | ‘8’ | ‘9’

    NumWithDig := NonZeroNums {Nums}
    Nums := Zero | NonZeroNums

    PosNum := ['+'] NumWithDig
    NegNum :=  '-'  NumWithDig

Bool := True | False
    True := '01'
    False := '00'　

Variable := IntVariable | BoolVariable
    IntVariable := Str {Str | Nums+}
    BoolVaiable := Str {Str | Nums+}

Substitution := IntSubstitution | BoolSubstitution
    IntSubstitution := IntVariable '=' ComparExpr
    BoolSubstitution := BoolVariable '=' ArithExpr


Expr := ArithExpr | LogicExpr | ComparExpr
    
    ArithExpr := IntVariable | ArithExpr ArithOper ArithExpr
        ArithOper := '+' | '-' | '*' | '/' | '%'

    LogicExpr := BoolVariable | ComparExpr | LogocExpr LogicOper LogocExpr
        LogicOper := '&' | '|' | '!' 

    ComparExpr := Variable | ArithExpr | LogicExpr | ComparExpr ComparOper ComparExpr
        ComparOper := '<' | '>' | '<=' | '>=' | '==' | '!='


Function := If | For | Movement | Area | Damage | Str {Str | Nums+} '(' [Argment ',']+ ')'
    
    Sentence　:= Substitution | Function

    Argument := IntArgument | BoolArgument
        IntArgument := IntVariable | Int
        BoolArgument := BoolVariable | Bool

    If := 'If' '(' ComparExpr ',' WhenTrue [ ',' WhenFalse ] ')'
        WhenTrue := Sentence
        WhenFalse := Sentence

    For := 'For' '(' Start ',' End (',' WhenLoop)+ ')' 
        Start := IntSubstitution
        End := IntArgment
        WhenLoop := Sentence

    Movement := 'Movement' '(' Type ',' Spead [',' Lotation ] ')'
        Type := IntArgment
        Spead := IntArgment
        Latation := IntArgment

    Area := 'Area' '(' Radius ',' Time ',' Angle ')'
        Radius := IntArgment
        Time := IntArgment
        Angle := IntArgment

    Damage := 'Damage' '(' Physics ',' Stun ')'
        Physics := IntArgment
        Stun := IntArgment
```
