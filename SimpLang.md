
```BNF

Str := Char+
    Lower := Regular[a-z]
    Upper := Regular[A-Z]
    Under := '_'

    Char := Lower | Upper | Under

Int := PosNum | Zero | NegNum
    Zero := '0'
    NonZeroNums :=  ‘1’ | ‘2’ | ‘3’ | ‘4’ | ‘5’ | ‘6’ | ‘7’ | ‘8’ | ‘9’

    NumWithDig = NonZeroNums {Nums}
    Nums := Zero | NonZeroNums

    PosNum := ['+'] NumWithDig
    NegNum :=  '-'  NumWithDig

Bool := True | False
    True := '01'
    False := '00'　

Variable := IntVariable | BoolVaiable
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

    If := 'if' '(' ComparExpr ',' WhenTrue [ ',' WhenFalse ] ')'
        WhenTrue := Sentence
        WhenFalse := Sentence

    For := 'for' '(' Start ',' End ',' WhenLoop ')' 
        Start := IntSubstitution
        End := IntArgment
        WhenLoop := Sentence

    Movement := 'movement' '(' Type ',' Spead [',' Lotation ] ')'
        Type := IntArgment
        Spead := IntArgment
        Latation := IntArgment

    Area := 'area' '(' Radius ',' Time ',' Angle ')'
        Radius := IntArgment
        Time := IntArgment
        Angle := IntArgment

    Damage := 'damage' '(' Physics ',' Stun ')'
        Physics := IntArgment
        Stun := IntArgment

```
