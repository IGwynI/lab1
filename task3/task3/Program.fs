open System

// Сложение
let add real1 imaginary1 real2 imaginary2 =
    let real = real1 + real2
    let imaginary = imaginary1 + imaginary2
    if imaginary < 0. then
        printfn "Сумма: %f - %fi" real (-imaginary)
    else
        printfn "Сумма: %f + %fi" real imaginary

// Вычитание
let subtract real1 imaginary1 real2 imaginary2 =
    let real = real1 - real2
    let imaginary = imaginary1 - imaginary2
    if imaginary < 0. then
        printfn "Разность: %f - %fi" real (-imaginary)
    else
        printfn "Разность: %f + %fi" real imaginary

// Умножение
let multiply real1 imaginary1 real2 imaginary2 =
    let real = real1 * real2 - imaginary1 * imaginary2
    let imaginary = real1 * imaginary2 + imaginary1 * real2
    if imaginary < 0. then
        printfn "Произведение: %f - %fi" real (-imaginary)
    else
        printfn "Произведение: %f + %fi" real imaginary

// Деление
let divide real1 imaginary1 real2 imaginary2 =
    let denominator = real2 * real2 + imaginary2 * imaginary2
    if denominator = 0. then
        printfn "Ошибка: деление на ноль"
    else
        let real = (real1 * real2 + imaginary1 * imaginary2) / denominator
        let imaginary = (imaginary1 * real2 - real1 * imaginary2) / denominator
        if imaginary < 0. then
            printfn "Частное: %f - %fi" real (-imaginary)
        else
            printfn "Частное: %f + %fi" real imaginary

// Степень
let rec pow_multiply accReal accImag baseReal baseImag power =
    if power = 0 
    then 
        (accReal, accImag)
    else
        let newReal = accReal * baseReal - accImag * baseImag
        let newImag = accReal * baseImag + accImag * baseReal
        pow_multiply newReal newImag baseReal baseImag (power - 1)

let pow real imag power =
    if power <= 0 then
        printfn "Ошибка: степень должна быть положительной"
    else
        let (real, imaginary) = pow_multiply 1. 0. real imag power
        if imaginary < 0. then
            printfn "Результат возведения в степень: %f - %fi" real (-imaginary)
        else
            printfn "Результат возведения в степень: %f + %fi" real imaginary


let readComplex message =
    printfn "%s" message
    printf "Действительная часть: "
    let real = float(Console.ReadLine())
    printf "Мнимая часть: "
    let imaginary = float(Console.ReadLine())
    (real, imaginary)


let readInt message =
    printf "%s" message
    int(Console.ReadLine())


[<EntryPoint>]
let main _ =
    printfn "Выберите номер операции:"
    printfn "  1. Сложение"
    printfn "  2. Вычитание"
    printfn "  3. Умножение"
    printfn "  4. Деление"
    printfn "  5. Возведение в степень (положительная степень)"
    
    match Console.ReadLine() with
    | "1" ->
        let (real1, imaginary1) = readComplex "Введите первое число:"
        let (real2, imaginary2) = readComplex "Введите второе число:"
        add real1 imaginary1 real2 imaginary2

    | "2" ->
        let (real1, imaginary1) = readComplex "Введите первое число:"
        let (real2, imaginary2) = readComplex "Введите второе число:"
        subtract real1 imaginary1 real2 imaginary2

    | "3" ->
        let (real1, imaginary1) = readComplex "Введите первое число:"
        let (real2, imaginary2) = readComplex "Введите второе число:"
        multiply real1 imaginary1 real2 imaginary2

    | "4" ->
        let (real1, imaginary1) = readComplex "Введите первое число:"
        let (real2, imaginary2) = readComplex "Введите второе число:"
        divide real1 imaginary1 real2 imaginary2

    | "5" ->
        let (real, imaginary) = readComplex "Введите комплексное число:"
        let power = readInt "Введите целую положительную степень: "
        pow real imaginary power

    | _ ->
        printfn "Неверный выбор операции"

    0