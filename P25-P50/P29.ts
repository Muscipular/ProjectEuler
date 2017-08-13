    let cx = 100;
    let c = 0;
    let dx = new Map<number, { a: number, b: number, m: Set<number> }>();
    for (let a = 2; a <= cx; a++) {
        let ta = a;
        let rb = 1;
        let b = 1;
        if (dx.has(a)) {
            ta = dx.get(a).a;
            rb = dx.get(a).b;
        }
        for (; b <= cx; b++) {
            if (ta === a) {
                let k = a ** b;
                if (k <= cx) {
                    dx.set(k, {a: a, b: b, m: new Set()})
                }
            }
            if (!dx.get(ta).m.has(b * rb)) {
                dx.get(ta).m.add(b * rb);
                if (b > 1)
                    c++;
            }
        }
    }
    console.log(c);
