
    let cmax = 0;
    let max = 0;
    for (let i = 1; i < 1000; i++) {
        let res = [];
        let target = 1;
        let mod = [target];
        while (target !== 0) {
            if (target < i) {
                res.push(0);
                target *= 10;
                continue;
            }
            res.push((target / i) >>> 0);
            let mo = target % i;
            if (mod.indexOf(mo) >= 0) {
                break;
            }
            mod.push(mo);
            target = mo * 10;
        }
        if (target !== 0) {
            if (max < res.length) {
                cmax = i;
                max = res.length;
            }
            console.log(i, res.join(""))
        }
    }
    console.log(cmax);
