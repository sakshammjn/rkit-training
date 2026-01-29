console.log("=== FOOD DELIVERY SYSTEM STARTED ===");

// =======================================
// USER INPUT (RAW DATA)
// =======================================
let customerName = "   saksham   ";
let restaurantName = "Pizza Palace";
let deliveryCity = "ahmedabad";
let couponCode = " SAVE50 ";

// =======================================
// STRING METHODS DEMO
// =======================================

// Trim whitespace
customerName = customerName.trim();
couponCode = couponCode.trim();

// Capitalize customer name
customerName =
  customerName.charAt(0).toUpperCase() +
  customerName.slice(1).toLowerCase();

// City formatting
deliveryCity = deliveryCity.toUpperCase();

// Check coupon
const isCouponValid = couponCode.toUpperCase() === "SAVE50";

// Extract first 3 letters of restaurant
const restaurantShortCode = restaurantName.substring(0, 3).toUpperCase();

// Replace spaces
const restaurantSlug = restaurantName.replace(" ", "-").toLowerCase();

// String includes
const isPizzaRestaurant = restaurantName.includes("Pizza");

// =======================================
// MATH METHODS DEMO
// =======================================

// Prices
const pizzaPrice = 299.75;
const deliveryFee = 40.5;

// Total before discount
let totalAmount = pizzaPrice + deliveryFee;

// Apply discount
let discount = isCouponValid ? 50 : 0;
totalAmount -= discount;

// Rounding
totalAmount = Math.round(totalAmount);

// Random Order ID
const orderId = Math.floor(Math.random() * 100000);

// Max & Min demo
const maxAllowedDiscount = Math.min(discount, 100);
const minOrderValue = Math.max(totalAmount, 100);

// Power & sqrt demo
const rewardPoints = Math.pow(2, 3); // 8 points
const distanceKm = Math.sqrt(64); // 8 km

// =======================================
// DATE & TIME OPERATIONS DEMO
// =======================================

// Order placed time
const orderTime = new Date();

// Delivery estimate (30 minutes later)
const deliveryTime = new Date(orderTime);
deliveryTime.setMinutes(deliveryTime.getMinutes() + 30);

// Date formatting
const orderDate = orderTime.toDateString();
const orderClockTime = orderTime.toLocaleTimeString();

// Extract date parts
const year = orderTime.getFullYear();
const month = orderTime.getMonth() + 1; // months start from 0
const day = orderTime.getDate();
const hour = orderTime.getHours();

// =======================================
// FINAL OUTPUT
// =======================================
console.log("\n=== ORDER SUMMARY ===");
console.log("Customer Name:", customerName);
console.log("Restaurant:", restaurantName);
console.log("Restaurant Code:", restaurantShortCode);
console.log("Restaurant Slug:", restaurantSlug);
console.log("City:", deliveryCity);
console.log("Is Pizza Restaurant:", isPizzaRestaurant);

console.log("\n=== BILL DETAILS ===");
console.log("Pizza Price:", pizzaPrice);
console.log("Delivery Fee:", deliveryFee);
console.log("Discount Applied:", maxAllowedDiscount);
console.log("Final Amount:", totalAmount);
console.log("Minimum Order Check:", minOrderValue);

console.log("\n=== ORDER META ===");
console.log("Order ID:", orderId);
console.log("Reward Points Earned:", rewardPoints);
console.log("Delivery Distance (km):", distanceKm);

console.log("\n=== TIME DETAILS ===");
console.log("Order Date:", orderDate);
console.log("Order Time:", orderClockTime);
console.log("Expected Delivery Time:", deliveryTime.toLocaleTimeString());
console.log("Order Year:", year, "Month:", month, "Day:", day, "Hour:", hour);

console.log("\n=== FOOD DELIVERY SYSTEM COMPLETED ===");
