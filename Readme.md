# Sửa DB:

# Validate:
- Validate Painting có AwardId và RoundId không cùng trong 1 cuộc thi
- Bắt validate add RoundTOpic ( Add Trùng)
- Bắt validate add PaintingCollection (Add Trùng)
- Chưa bắt validate date contest
- Tên topic khônng trùng nhau
- Validate tuổi khi đăng ký vào contest

# Sửa: 
- xem các cuộc thi
- xem chi tiết cuộc thi
- xem các bộ sưu tập
- xem các thí sinh có giải 5 năm gần đây
- Nếu xóa Contest thì status của những bảng liên quan sẽ đổi luôn
- Sửa Output cho GetContestById
- (Xóa Contest sẽ đổi status của những bảng link Contest(Level, Round, Topic, Sponsor

- Lấy tranh lấy luôn award 
- Chuyển Stauts của report
- Get Painting By AccountId
- Đổi path Get Paintg By Collection(Controller)
- Lấy ra roundid topicid từ roundtopicid trong painting (paiting view model)


- Tạo Round add cho toàn bộ level (thay levelid = contestid) với bỏ listtopic.
- Add nhiều topicround
- get alltopic (không phân trang)
- 
