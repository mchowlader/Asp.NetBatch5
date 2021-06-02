var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var message = "hello world";
var num = 10;
var num2, num3;
num3 = 10;
var isDone = true;
var list2 = [1, 2, 3];
var list1 = ['a', 'b'];
console.log(list);
var list = ["a"];
console.log(list);
var Hello = /** @class */ (function () {
    function Hello(message) {
        this.text = message;
    }
    Hello.prototype.Add = function (num1, num2) {
        return num1 + num2;
    };
    return Hello;
}());
var obj1 = new Hello("Bangladesh");
console.log(obj1.text);
console.log(obj1.Add(2, 2));
var National = /** @class */ (function () {
    function National() {
        this.age = 10;
        this.name = "Mithun";
        this.address = "17,dhaka";
    }
    National.prototype.Info = function (num1, num2) {
        return num1 + num2;
    };
    return National;
}());
var identity = new National();
console.log("1st:", identity.Info(2, 2), identity.name, identity.address);
var mem = {
    name: "MI",
    age: 20,
    address: "DHAKA",
    value: "Hi",
    Info: function (x, y) {
        return x + y;
    }
};
console.log("2nd:", mem.Info(1, 1));
var Human = /** @class */ (function () {
    function Human() {
    }
    Human.prototype.Sum = function (num1, num2) {
        return num1 + num2;
    };
    return Human;
}());
var People = /** @class */ (function (_super) {
    __extends(People, _super);
    function People() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return People;
}(Human));
var m = new People();
var y = m.Sum(2, 2);
console.log(y);
var x = {
    CName: "M",
    Name: "A",
    Price: 10,
    Info: function (x) {
        return x;
    }
};
console.log(x.CName, x.Name, x.Price);
console.log(x.Info("xx"));
var Human2 = /** @class */ (function () {
    function Human2(type) {
        this.Type = type;
    }
    Human2.prototype.Move = function (km) {
        console.log(this.Type + "  move to daily " + km + "km.");
    };
    return Human2;
}());
var hInstance = new Human2("Man");
hInstance.Move(5);
var Human3 = /** @class */ (function () {
    function Human3(type) {
        this.Type = type;
    }
    Human3.prototype.Move = function (km) {
        console.log(this.Type + "  move to daily " + km + "km.");
    };
    return Human3;
}());
var Man = /** @class */ (function (_super) {
    __extends(Man, _super);
    function Man() {
        return _super.call(this, "Man") || this;
    }
    return Man;
}(Human3));
var Animal = /** @class */ (function () {
    function Animal(name) {
        this.Name = name;
    }
    return Animal;
}());
var human3 = new Human3("People");
var man = new Man();
var animal = new Animal("Dog");
human3 = man;
function Structure(info) {
    var hunmanInfo = { name: "Mithun", age: 25 };
    if (info.names) {
        hunmanInfo.name = info.names;
    }
    if (info.ages) {
        hunmanInfo.age = info.ages;
    }
    return hunmanInfo;
}
var value = Structure({ names: "Howlader", ages: 26 });
console.log(value);
//========================================
var preactices1 = /** @class */ (function () {
    function preactices1(name) {
        this.Name = name;
    }
    return preactices1;
}());
var name2 = new preactices1("A");
console.log(name2.Name);
var preactices = /** @class */ (function () {
    function preactices() {
        this.Name = "M";
    }
    return preactices;
}());
var name1 = new preactices();
console.log(name1.Name);
//===========================================
var maxTextLength = 10;
var SetName = /** @class */ (function () {
    function SetName() {
        this._Name = "Anna";
    }
    Object.defineProperty(SetName.prototype, "fullname", {
        get: function () {
            return this._Name;
        },
        set: function (newName) {
            if (newName.length > maxTextLength) {
                throw new Error("max length " + maxTextLength);
            }
            else {
                this._Name = newName;
            }
        },
        enumerable: false,
        configurable: true
    });
    return SetName;
}());
var sn = new SetName();
console.log(sn.fullname);
console.log(sn.fullname = "Mariahgffhffgf");
//==================
var DemoCounter = /** @class */ (function () {
    function DemoCounter() {
        this.name = "";
    }
    DemoCounter.prototype.Increment = function (name) {
        DemoCounter.counter++;
        this.name = name;
    };
    DemoCounter.DoSomething = function () {
        console.log("This is printing by staic method!!!");
    };
    DemoCounter.counter = 0;
    return DemoCounter;
}());
var demo1 = new DemoCounter();
var demo2 = new DemoCounter();
demo1.Increment("one");
demo1.Increment("two");
demo2.Increment("three");
console.log(demo1.name);
console.log(demo2.name);
console.log("Counter: ", DemoCounter.counter);
DemoCounter.DoSomething();
//====================================
var Grid = /** @class */ (function () {
    function Grid(scale) {
        this.scale = scale;
    }
    Grid.prototype.calculateDistanceFormOrigin = function (point) {
        var xDist = point.x - Grid.origin.x;
        var yDist = point.y - Grid.origin.y;
        return Math.sqrt(xDist * xDist + yDist * yDist) / this.scale;
    };
    Grid.origin = { x: 0, y: 0 };
    return Grid;
}());
var grid1 = new Grid(1.0);
var grid2 = new Grid(5.0);
console.log("grid1 = " + grid1.calculateDistanceFormOrigin({ x: 10, y: 10 }));
console.log("grid2 = " + grid2.calculateDistanceFormOrigin({ x: 10, y: 10 }));
//# sourceMappingURL=DemoTypeScript.js.map