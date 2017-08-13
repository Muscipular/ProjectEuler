    let cache = {prime: [], max: 0};
    const isPrime = ((cache: { prime: Array<number>, max: number }) => function (n: number) {
        if (n < 1) {
            return false;
        }
        if (cache.prime.indexOf(n) >= 0) {
            return true;
        }
        let d = ~~Math.sqrt(n);
        if (cache.max < d) {
            for (let i = ~~((cache.max + 1) / 2) * 2; i <= d; i += 2) {
                let ok = true;
                for (let c of cache.prime) {
                    if (i % c === 0) {
                        ok = false;
                        break;
                    }
                }
                if (ok && cache.prime.indexOf(i) < 0) {
                    cache.prime.push(i);
                }
            }
        }
        for (let c of cache.prime) {
            if (c > d) {
                break;
            }
            if (n % c === 0 && c !== n && c !== 1) {
                return false;
            }
        }
        cache.prime.push(n);
        return true;
    })(cache);

    // [1, 2, 3, 5, 7, 11].forEach(x => isPrime(x).should.equal(true, x.toString()));
    // isPrime(41).should.true();
    // [22, 4, 10, 21, 44, 100].forEach(x => isPrime(x).should.equal(false, x.toString()));

    let max = 0;
    let pro = 0;
    for (let i = -1000; i <= 1000; i++) {
        for (let j = -1000; j <= 1000; j++) {
            let c = 0;
            while ((n => isPrime(n * n + i * n + j))(c)) {
                c++;
            }
            if (c > max) {
                pro = i * j;
                max = c;
            }
        }
    }
    console.log(max, pro, cache.prime[cache.prime.length - 1]);
