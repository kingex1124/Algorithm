window.onload = function () {
   
    var result = anagrams("One onb", "One one");
}

function anagrams(stringA, stringB) {
    const aCharMap = buildCharMap(stringA);
    const bCharMap = buildCharMap(stringB);

    if (Object.keys(aCharMap).length !== Object.keys(bCharMap).length)
        return false;
    for (let char in aCharMap)
        if (aCharMap[char] != bCharMap[char])
            return false;

    return true;
}

function buildCharMap(str) {
    const charMap = {};
    for (let char of str.replace(/[^\w]/g, '').toLowerCase())
        charMap[char] = charMap[char] + 1 || 1;

    return charMap;
}

//function anagrams(stringA, stringB) {
//    const charMap = {};
//    stringA = stringA.replace(/[^\w]/g, "").toLowerCase();
//    stringB = stringB.replace(/[^\w]/g, "").toLowerCase();
//    for (let char of stringA)
//        charMap[char] = charMap[char] + 1 || 1;
//    for (let char of stringB)
//        charMap[char] = (charMap[char] - 1);
//    for (let char in charMap)
//        if (charMap[char] != 0)
//            return false;
//    return true;
//}