    class N {
        private data = [];

        constructor(n: N | number | string) {
            if (typeof n === "number") {
                if (n.toString().indexOf('e') > 0) {
                    n = n.toString();
                } else {
                    let c = +/e\+(\d+)/.exec(n.toExponential())[1];
                    while (c >= 0) {
                        this.data[c] = ~~(n / 10 ** c);
                        n = n % (10 ** c);
                        c--;
                    }
                }
            }
            if (typeof  n === "string") {
                n = n.replace(/\./, "").replace(/(\d+)e\+(\d+)/, (a, l, d) => l + "0".repeat(+d - l.length + 1));
                this.data = n.split('').map(x => +x).reverse();
            }
            if (n instanceof N) {
                this.data = n.data.concat([]);
            }
        }

        public add(n: N | number) {
            let n2 = new N(n);
            let t = Math.max(this.data.length, n2.data.length);
            let c = 0;
            let target = new N(0);
            for (let i = 0; i < t; i++) {
                let a = this.getN(i);
                let b = n2.getN(i);
                c = a + b + c;
                target.setN(i, c % 10);
                c = ~~(c / 10);
            }
            if (c > 0) {
                target.setN(t, c);
            }
            return target;
        }

        private getN(n: number) {
            return this.data[n] || 0;
        }

        private setN(n: number, val: number) {
            return this.data[n] = val;
        }

        toString(): string {
            return this.data.map(x => x || 0).reverse().join('');
        }

        toNumber(): number {
            return +this.toString();
        }

        inspect() {
            return this.toString();
        }

        get length() {
            return this.data.length;
        }
    }

    // [1, 2, 3, 4, 10, 1e20, 1234556789, 12301239].forEach(n => {
    //
    //     new N(n).toString().should.equal(n.toString());
    // });
    // [1.1232130e234].forEach(n => {
    //     new N(n).toNumber().should.equal(n);
    // });
    //
    // [[1, 2], [1300210012, 1], [213213, 2323221], [2.13e110, 2.333131313e100], [9, 9], [45678, 54322], [45678, 54523]].forEach(l => {
    //     new N(l[0]).add(new N(l[1])).toNumber().should.equal(l[0] + l[1]);
    // })
    function fab(a) {
        if (fab['cache'][a]) {
            return fab['cache'][a];
        }
        return fab['cache'][a] = a <= 2 ? 1 : new N(fab(a - 1)).add(fab(a - 2));
    }

    fab['cache'] = {};
    let i = 10;
    while (fab(++i).length < 1000) {
    }
    console.log(i);
