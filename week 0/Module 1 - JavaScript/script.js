// core javascript for handling logic in training portal
// author: deepa nair

// types and variables demo
const title = "City Council Events Portal";
let currentViews = 500;
let isPortalLive = true;

console.log("running initial setup...");

// age filter checking with exception handling
function checkEligibility(age) {
    try {
        if (age < 0) {
            throw new Error("Age cannot be a negative value!");
        }
        return age >= 18 ? "Eligible for Main Event" : "Eligible for Kids Event";
    } catch (e) {
        console.error("Age check failed:", e.message);
        return "Invalid Data";
    }
}

// array mapping/filtering
const sampleAges = [25, 12, 17, 30, -3];
sampleAges.forEach((age, index) => {
    let status = checkEligibility(age);
    console.log("Index " + index + " (Age: " + age + "): " + status);
});

// closure tracking seat counts
function createSeatManager(total) {
    let reserved = 0;
    return {
        book: function() {
            if (reserved < total) {
                reserved++;
                return "Seat booked. Count: " + reserved + "/" + total;
            }
            return "No seats left!";
        },
        remaining: () => total - reserved
    };
}

const manager = createSeatManager(5);
console.log(manager.book());
console.log(manager.book());

// prototypes logic
function EventSummary(name, location) {
    this.name = name;
    this.location = location;
}
EventSummary.prototype.info = function() {
    return this.name + " is happening at " + this.location;
};

const ev1 = new EventSummary("Food Fest", "Central Park");
console.log(ev1.info());