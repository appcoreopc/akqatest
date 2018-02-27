const num = "ZERO ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE TEN ELEVEN TWELVE THIRTEEN FOURTEEN FIFTEEN SIXTEEN SEVENTEEN EIGHTEEN NINETEEN".split(" ");
const tens = "TWENTY THIRTY FOURTY FIFTY SIXTY SEVENTY EIGHTY NINETY".split(" ");

export function number2words(n)
{
    let n1 = Math.floor(n);
    let n2 = fract(n);
    let n3 = numberWord(n1);
    let n4 = numberWord(n2) + ' cents';        
    return n3 + ' AND ' + n4;
}

export function numberWord (n) {

    if (n < 20) return num[n];
    var digit = n%10;
    if (n < 100) return tens[~~(n/10)-2] + (digit? "-" + num[digit]: "");
    if (n < 1000) return num[~~(n/100)] +" HUNDRED" + (n%100 == 0? "": " " + numberWord(n%100));
    return numberWord(~~(n/1000)) + " THOUSAND" + (n%1000 != 0? " " + numberWord(n%1000): "");
}

function fract(n){ return Number(String(n).split('.')[1] || 0); }
