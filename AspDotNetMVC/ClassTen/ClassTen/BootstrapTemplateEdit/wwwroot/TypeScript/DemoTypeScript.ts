let message: string = "hello world";


let num: number = 10;
let num2, num3: number;
num3 = 10;

let isDone: boolean = true;


let list2: number[] = [1, 2, 3];


let list1: string[] = ['a', 'b'];
console.log(list);

var list: Array<string> = ["a"];
console.log(list);

class Hello {
    text: string;
    constructor(message: string) {
        this.text = message;
    }

    Add(num1: number, num2: number): number {
        return num1 + num2;

    }
}

let obj1 = new Hello("Bangladesh");
console.log(obj1.text);

console.log(obj1.Add(2, 2));

interface IPerson {
    name: string;
    age: number;
    address: any;

    Info(num1: number, num2: number): number;
}

class National implements IPerson {
    Nid: any;
    age = 10;
    name = "Mithun";
    address = "17,dhaka";
    Info(num1: number, num2: number): number {
        return num1 + num2;
    }
}


interface Imember extends IPerson {
    value: string;
}

let identity = new National();
console.log("1st:", identity.Info(2, 2), identity.name, identity.address);

let mem: Imember = {
    name: "MI",
    age: 20,
    address: "DHAKA",
    value: "Hi",
    Info(x, y) {
        return x + y;
    }

}
console.log("2nd:", mem.Info(1, 1));
class Human {



    Sum(num1: number, num2: number): number {
        return num1 + num2;
    }

}

class People extends Human {

}

let m = new People()
let y = m.Sum(2, 2)
console.log(y);


interface IVehicale {
    Name: string;
    Price: number;

}

interface Car extends IVehicale {

    CName: string;

    Info(n: string): string;


}
let x: Car = {

    CName: "M",
    Name: "A",
    Price: 10,
    Info(x: string): string {
        return x;
    }

}

console.log(x.CName, x.Name, x.Price);
console.log(x.Info("xx"));


class Human2 {
    public Type: string;

    constructor(type: string) {
        this.Type = type;
    }

    public Move(km: number) {
        console.log(`${this.Type}  move to daily ${km}km.`);
    }
}

let hInstance = new Human2("Man");
hInstance.Move(5);



class Human3 {
    public Type: string;

    constructor(type: string) {
        this.Type = type;
    }

    public Move(km: number) {
        console.log(`${this.Type}  move to daily ${km}km.`);
    }
}

class Man extends Human3 {
    constructor() {
        super("Man");
    }

}


class Animal {
    private Name: string;
    constructor(name: string) {
        this.Name = name;
    }

}

let human3 = new Human3("People");
let man = new Man();
let animal = new Animal("Dog");

human3 = man;
//human3 = animal;//error

//=================================
interface Person {
    names?: string;
    ages?: number;
}

function Structure(info: Person): { name: string, age: number } {
    let hunmanInfo = { name: "Mithun", age: 25 };

    if (info.names) {
        hunmanInfo.name = info.names;

    }
    if (info.ages) {
        hunmanInfo.age = info.ages;
    }
    return hunmanInfo;
}


let value = Structure({ names: "Howlader", ages: 26 });
console.log(value);
//========================================
class preactices1 {
    readonly Name: string;
    constructor(name: string) {
        this.Name = name;
    }
}

let name2 = new preactices1("A");
console.log(name2.Name);

class preactices {
    readonly Name: string = "M";
    constructor() {

    }
}

let name1 = new preactices();
console.log(name1.Name);

//===========================================
const maxTextLength: number = 10;

class SetName {
    private _Name: string = "Anna";

    get fullname(): string {
        return this._Name;
    }

    set fullname(newName: string) {
        if (newName.length > maxTextLength) {
            throw new Error("max length " + maxTextLength);
        }
        else {
            this._Name = newName;
        }
    }
}

let sn = new SetName();

console.log(sn.fullname);
console.log(sn.fullname = "Mariahgffhffgf");



//==================
class DemoCounter {
    static counter: number = 0;
    name: string = "";

    Increment(name: string): void {
        DemoCounter.counter++;
        this.name = name;
    }

    static DoSomething(): void {
        console.log("This is printing by staic method!!!");
    }
}

let demo1 = new DemoCounter();
let demo2 = new DemoCounter();

demo1.Increment("one");
demo1.Increment("two");

demo2.Increment("three");

console.log(demo1.name);
console.log(demo2.name);
console.log("Counter: ", DemoCounter.counter);

DemoCounter.DoSomething();

//====================================
class Grid {
    static origin = { x: 0, y: 0 }

    constructor(public scale: number) { }

    calculateDistanceFormOrigin(point: { x: number, y: number }) {
        let xDist = point.x - Grid.origin.x;
        let yDist = point.y - Grid.origin.y;

        return Math.sqrt(xDist * xDist + yDist * yDist) / this.scale;
    }

}

let grid1 = new Grid(1.0);

let grid2 = new Grid(5.0);

console.log(`grid1 = ${grid1.calculateDistanceFormOrigin({ x: 10, y: 10 })}`);

console.log(`grid2 = ${grid2.calculateDistanceFormOrigin({ x: 10, y: 10 })}`);

//==============================

namespace Validation {
    export interface StringVadilator {
        isAcceptable(s: string): boolean;
    }

    const lettersRegexp = /^[A-Za-z]+$/;
    const numberRegexp = /^[0-9]+$/;

    export class letterValidator implements StringVadilator {
        isAcceptable(s: string) {
            return lettersRegexp.test(s);
        }
    }

    export class zipValidator implements StringVadilator {
        isAcceptable(s: string) {
            return s.length == 4 && numberRegexp.test(s);
        }
    }
}


let strings = ["Hello", "1216", "101"];

let validations: { [s: string]: Validation.StringVadilator } = {};

validations["zip"] = new Validation.zipValidator();
validations["letter"] = new Validation.letterValidator();

for (let i of strings) {
    for (let name in validations) {
        console.log(`${i}- ${validations[name].isAcceptable(i) ? "match:" : "Does not match"} ${name}`);
    }
}



