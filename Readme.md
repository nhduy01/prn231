# Sửa DB:
- Sửa Cash với Artifact trong Resource thành 1 cột
- Xóa description category
- Xóa Image trong Topic
- Thêm Image trong Sponsor
- Thêm Content trong post
- RoundTopic có thêm status 
- URL trong Post
- Thêm image trong contest

# Validate:
- Validate Painting có AwardId và RoundId không cùng trong 1 cuộc thi
- Bắt validate add RoundTOpic ( Add Trùng)
- Bắt validate add PaintingCollection (Add Trùng)
- Chưa bắt validate date contest
- 

# Sửa: 
- xem các cuộc thi
- xem chi tiết cuộc thi
- xem các bộ sưu tập
- xem các thí sinh có giải 5 năm gần đây
- Nếu xóa Contest thì status của những bảng liên quan sẽ đổi luôn
- Sửa Output cho GetContestById
- (Xóa Contest sẽ đổi status của những bảng link Contest(Level, Round, Topic, Sponsor

- Chuyển Stauts của report
- Get Painting By AccountId
- Đổi path Get Paintg By Collection(Controller)
- Lấy ra roundid topicid từ roundtopicid trong painting (paiting view model)
