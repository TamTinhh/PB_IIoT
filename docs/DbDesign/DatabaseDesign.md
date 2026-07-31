# Database Design

**Project:** Industrial Monitor  
**Version:** 1.0  
**Author:** Nguyễn Tâm Tính  
**Updated:** 2026-07-30

---

# 1. Giới thiệu

## Mục đích

Cơ sở dữ liệu được thiết kế để phục vụ hệ thống **Industrial Monitor**, có chức năng:

- Quản lý Gateway
- Quản lý thiết bị Modbus
- Quản lý Tag dữ liệu
- Lưu dữ liệu lịch sử
- Quản lý Alarm
- Quản lý người dùng
- Ghi nhật ký hệ thống

Database sử dụng:

- Microsoft SQL Server

---

# 2. Sơ đồ quan hệ

Gateway (1)
│
└──────< Device (N)
│
└──────< DeviceTag (N)
│
├──────────────< Measurement (N)
│
└──────────────< AlarmRule (N)
│
└──────────────< AlarmHistory (N)

User (1)
│
└──────────────< AlarmHistory (AcknowledgeBy)

---

# 3. Danh sách bảng

| STT | Table |
|-----|-------|
| 1 | Gateway |
| 2 | Device |
| 3 | DeviceTag |
| 4 | Measurement |
| 5 | AlarmRule |
| 6 | AlarmHistory |
| 7 | User |
| 8 | SystemLog |

---

# 4. Gateway

## Mô tả

Lưu thông tin Gateway 3Onedata.

## Primary Key

GatewayId

## Các trường

| Field | Type | Description |
|--------|------|-------------|
| GatewayId | INT IDENTITY | Primary Key |
| GatewayCode | VARCHAR(30) | Mã Gateway |
| GatewayName | NVARCHAR(100) | Tên Gateway |
| Model | NVARCHAR(50) | Model |
| IPAddress | VARCHAR(20) | Địa chỉ IP |
| Port | INT | Port TCP |
| Status | BIT | Online/Offline |
| Location | NVARCHAR(100) | Vị trí |
| CreatedAt | DATETIME2 | Ngày tạo |
| UpdatedAt | DATETIME2 | Ngày cập nhật |

---

# 5. Device

## Mô tả

Lưu danh sách thiết bị kết nối với Gateway.

## Quan hệ

Gateway (1) -----> Device (N)

## Primary Key

DeviceId

## Foreign Key

GatewayId

## Các trường

| Field | Type |
|--------|------|
| DeviceId | INT |
| GatewayId | INT |
| DeviceCode | VARCHAR(30) |
| DeviceName | NVARCHAR(100) |
| Model | NVARCHAR(50) |
| Manufacturer | NVARCHAR(50) |
| Protocol | VARCHAR(30) |
| SlaveId | INT |
| BaudRate | INT |
| DataBits | TINYINT |
| Parity | VARCHAR(10) |
| StopBits | TINYINT |
| PollingIntervalMs | INT |
| Status | BIT |
| CreatedAt | DATETIME2 |

---

# 6. DeviceTag

## Mô tả

Định nghĩa các Tag dữ liệu của thiết bị.

## Quan hệ

Device (1) -----> DeviceTag (N)

## Primary Key

DeviceTagId

## Foreign Key

DeviceId

## Các trường

| Field | Type |
|--------|------|
| DeviceTagId | INT |
| DeviceId | INT |
| TagCode | VARCHAR(50) |
| TagName | NVARCHAR(100) |
| RegisterAddress | INT |
| FunctionCode | TINYINT |
| DataType | VARCHAR(20) |
| Scale | DECIMAL(10,4) |
| Unit | VARCHAR(20) |
| IsAlarmEnabled | BIT |
| IsHistoryEnabled | BIT |

---

# 7. Measurement

## Mô tả

Lưu toàn bộ dữ liệu lịch sử.

## Quan hệ

DeviceTag (1) -----> Measurement (N)

## Primary Key

MeasurementId

## Foreign Key

DeviceTagId

## Các trường

| Field | Type |
|--------|------|
| MeasurementId | BIGINT |
| DeviceTagId | INT |
| Value | DECIMAL(18,4) |
| Quality | TINYINT |
| Timestamp | DATETIME2 |

### Quality

| Value | Description |
|-------|-------------|
| 0 | Good |
| 1 | Timeout |
| 2 | CRC Error |
| 3 | Invalid |

---

# 8. AlarmRule

## Mô tả

Định nghĩa các điều kiện cảnh báo.

## Quan hệ

DeviceTag (1) -----> AlarmRule (N)

## Primary Key

AlarmRuleId

## Foreign Key

DeviceTagId

## Các trường

| Field | Type |
|--------|------|
| AlarmRuleId | INT |
| DeviceTagId | INT |
| AlarmName | NVARCHAR(100) |
| Condition | VARCHAR(10) |
| Threshold | DECIMAL(18,4) |
| Severity | TINYINT |
| IsEnable | BIT |

### Severity

| Value | Description |
|-------|-------------|
| 1 | Information |
| 2 | Warning |
| 3 | Critical |

---

# 9. AlarmHistory

## Mô tả

Lưu lịch sử phát sinh cảnh báo.

## Quan hệ

AlarmRule (1) -----> AlarmHistory (N)

User (1) -----> AlarmHistory (N)

## Primary Key

AlarmHistoryId

## Foreign Key

AlarmRuleId

AcknowledgeBy

## Các trường

| Field | Type |
|--------|------|
| AlarmHistoryId | BIGINT |
| AlarmRuleId | INT |
| Value | DECIMAL(18,4) |
| StartTime | DATETIME2 |
| EndTime | DATETIME2 NULL |
| AcknowledgeBy | INT NULL |
| Status | TINYINT |

---

# 10. User

## Mô tả

Quản lý người dùng hệ thống.

## Primary Key

UserId

## Các trường

| Field | Type |
|--------|------|
| UserId | INT |
| Username | VARCHAR(50) |
| PasswordHash | NVARCHAR(255) |
| FullName | NVARCHAR(100) |
| Email | VARCHAR(100) |
| Role | VARCHAR(30) |
| IsActive | BIT |

---

# 11. SystemLog

## Mô tả

Lưu nhật ký hoạt động của hệ thống.

## Primary Key

LogId

## Các trường

| Field | Type |
|--------|------|
| LogId | BIGINT |
| Module | VARCHAR(50) |
| Level | VARCHAR(20) |
| Message | NVARCHAR(MAX) |
| Detail | NVARCHAR(MAX) |
| CreatedAt | DATETIME2 |

---

# 12. Quy ước đặt tên

## Primary Key

Tên bảng + Id

Ví dụ:

- GatewayId
- DeviceId
- DeviceTagId

## Foreign Key

Tên bảng tham chiếu + Id

Ví dụ:

- GatewayId
- DeviceId
- DeviceTagId

## Thời gian

- CreatedAt
- UpdatedAt
- Timestamp

## Boolean

- IsActive
- IsEnable
- IsAlarmEnabled
- IsHistoryEnabled

---

# 13. Ghi chú

- Hệ thống sử dụng SQL Server.
- Quan hệ chính là 1-N.
- Measurement là bảng có tốc độ tăng dữ liệu lớn nhất.
- Khuyến nghị tạo Index cho:
  - Measurement(DeviceTagId, Timestamp)
  - Device(GatewayId)
  - DeviceTag(DeviceId)
  - AlarmHistory(AlarmRuleId)   