## 1. account & Registration


| Rule                   | Enforcement                                      |
| ---------------------- | ------------------------------------------------ |
| User must be 18+       | Application layer (validation using DateOfBirth) |
| Email is unique        | Database constraint                              |
| User must have role    | FK: UserRoleId                                   |
| Phone number is unique | Database constraint								|

## 2. Booking & Capacity

| Rule                                   | Enforcement           |
| -------------------------------------- | --------------------- |
| One booking per group                  | Application logic     |
| Confirmed booking reduces spots        | Application logic     |
| Pending booking does NOT reserve spots | Application logic     |
| Booking linked to User & Package       | FK: UserId, PackageId |

## 3. Payment Rules

| Rule                              | Enforcement            |
| --------------------------------- | ---------------------- |
| Payment linked to Booking         | FK: BookingId          |
| Payment type (Deposit/Full)       | Enum                   |
| Payment method (Stripe/Cash/Bank) | Enum                   |
| Payment deadline logic            | Application + Hangfire |

## 4. Passenger Rules

| Rule                         | Enforcement               |
| ---------------------------- | ------------------------- |
| Passenger belongs to booking | FK: BookingId             |
| Minor detection              | Application (DateOfBirth) |
| Guardian relationship        | Self FK: GuardianId       |
| Verification status          | Enum                      |
| Passport number is unique    | Database constraint	   |

## 5. Refund & Cancellation
| Rule                   | Enforcement       |
| ---------------------- | ----------------- |
| Refund based on time   | Application logic |
| Booking status changes | Enum              |

## 6. Notification

| Rule                        | Enforcement       |
| --------------------------- | ----------------- |
| Notification linked to user | FK: UserId        |
| Notification type           | Enum              |
| Created automatically       | Application logic |

## 7. Audit & Data Lifecycle

| Rule                  | Enforcement                 |
| --------------------- | --------------------------- |
| CreatedAt / CreatedBy | AppDbContext (UBS-21)       |
| UpdatedAt / UpdatedBy | AppDbContext                |
| Soft delete           | BaseEntity (planned ticket) |


## 8. Edge Cases & Notes

- Pending bookings expire after 24h → Hangfire
- Minors without guardian → admin validation
- Payment overdue → auto cancel
- Passenger data lock → application rule