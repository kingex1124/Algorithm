window.onload = function () {
    const test = [1, 2, 3, 4, 5];
    chunk(test, 2);
}

function chunk(array, size) {
    const chunked = [];
    let start = 0;
    while (start < array.length) {
        if (start + size < array.length) {
            chunked.push(array.slice(start, start + size));
            start = start + size;
        } else {
            chunked.push(array.slice(start, array.length - 1));
        }
    }
    return chunked;
}

//function chunk(array, size) {
//    const chunked = [];
//    for (let element of array) {
//        const last = chunked[chunked.length - 1];
//        if (!last || last.length === size) {
//            chunked.push([element]);
//        } else {
//            last.push(element);
//        }
//    }
//    return chunked;
//}

//function chunk(array, size) {
//    const arraySet = [];
//    for (var i = 1; i <= array.length; i++) {
//        let arrayTmp = [];
//        arrayTmp.push(array[i - 1]);
//        if (i % size === 0) {
//            arraySet.push(arrayTmp);
//            arrayTmp = [];
//        } else if (i === array.length && arrayTmp.length != 0)
//            arraySet.push(arrayTmp);
//    }
//    return arraySet;
//}