    let d1 = [1, 2, 5, 10, 20, 50, 100, 200];

    function c(top, e) {
        if (top === 0) {  //top === 0 意味刚好分配完硬币
            return 1;
        }
        if (e === 0) { //不符合分配咯
            return 0;
        }
        let count = 0;
        let mx = ~~(top / d1[e - 1]);
        for (let i = mx; i >= 0; i--) {
            count += c(top - i * d1[e - 1], e - 1)
        }
        return count;
    }

    console.log(c(200, d1.length));
    /*
    * 
    */
