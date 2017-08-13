 function fab(a) {
    if (fab['cache'][a]) {
        return fab['cache'][a];
    }
    return fab['cache'][a] = a <= 1 ? 1 : a * fab(a - 1);
}
fab['cache'] = {};
function t(target: number) {
    let arr = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    let res = [];
    target--;
    while (arr.length > 0) {
        let i = 0;
        for (i = 0; i < arr.length;) {
            if (fab(++i) - 1 >= target) {
                break;
            }
        }
        res.push.apply(res, arr.splice(0, arr.length - i));

        let f = fab(i - 1);
        let n = ~~((target) / f);
        target = target % f;
        res.push(arr.splice(n, 1)[0]);
    }
    return res.join('');
}

console.log(t(1000000));
