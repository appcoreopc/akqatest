

var num = "zero one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen".split(" ");
var tens = "twenty thirty forty fifty sixty seventy eighty ninety".split(" ");

export function number2words(n)
{
    let n1 = Math.floor(n);
    let n2 = fract(n);
    let n3 = numberWord(n1);
    let n4 = numberWord(n2) + ' cents';        
    return n3 + ' ' + n4;
}

export function numberWord (n) {

    if (n < 20) return num[n];
    var digit = n%10;
    if (n < 100) return tens[~~(n/10)-2] + (digit? "-" + num[digit]: "");
    if (n < 1000) return num[~~(n/100)] +" hundred" + (n%100 == 0? "": " " + numberWord(n%100));
    return numberWord(~~(n/1000)) + " thousand" + (n%1000 != 0? " " + numberWord(n%1000): "");
}

function fract(n){ return Number(String(n).split('.')[1] || 0); }
