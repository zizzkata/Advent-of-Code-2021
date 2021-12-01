const fs = require('fs')

fs.readFile('input', 'utf8', (err, data) => {
    if (err) {
        console.error(err)
        return
    }
    let array = data.split('\n');
    let counter1 = 0
    let counter2 = 0
    let sumPrev = Number(array[0]) + Number(array[1]) + Number(array[2])

    for (let i = 1; i < array.length; i++) {
        if(Number(array[i]) > Number(array[i-1]))
            counter1++ 
    }

    for (let i = 1; i < array.length - 1; i++) {
        currSum = Number(array[i - 1]) + Number(array[i]) + Number(array[i + 1])
        if(currSum > sumPrev)
            counter2++
        sumPrev = currSum;
    }

    console.log(counter1);
    console.log(counter2);
})
