    let q = 5;
    let o = Array.from({length: 10}).map((o, i) => i ** q);
    const mx = o[o.length - 1].toString().length + 2;
    let c = 0;

    for (let i = 2; i < o[9] * mx; i++) {
        let n = 0;
        let d = i;
        while (d > 0) {
            n += o[d % 10];
            d = ~~(d / 10);
        }
        if (n === i) {
            console.log(i);
            c += i;
        }
    }
    console.log(c)
