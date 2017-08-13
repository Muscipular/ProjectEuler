
    let m = (1001 >>> 1) + 1;
    let c = 0, p = 0;
    for (let i = 1; i <= m; i++) {
        if (i === 1) {
            c = 1;
            p = 1;
            continue;
        }
        let f = 2 * (i - 2) + 1;
        for (let j = 1; j <= 4; j++) {
            p += f + 1;
            c += p;
        }
    }
    console.log(c);
