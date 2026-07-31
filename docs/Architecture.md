# System Architecture

## Tổng quan

Industrial Monitor được xây dựng theo kiến trúc nhiều tầng nhằm tách biệt việc thu thập dữ liệu, lưu trữ và hiển thị.

---

## Kiến trúc hệ thống

```text
Modbus Device
      │
      ▼
3Onedata Gateway
      │
      ▼
Collector Service
      │
      ▼
SQL Server
      │
      ▼
ASP.NET Core Web API
      │
      ▼
Web Dashboard
```

---

## Luồng dữ liệu

1. Collector đọc dữ liệu Modbus.
2. Chuẩn hóa dữ liệu.
3. Ghi vào SQL Server.
4. Kiểm tra Alarm.
5. Dashboard lấy dữ liệu thông qua API.
6. Email được gửi khi có cảnh báo.

---

## Module

- Collector
- Database
- API
- Dashboard
- Alarm
- Email