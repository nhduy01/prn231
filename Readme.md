# Sửa DB:
- Allow null cho code painting
- 
- Edit và Delete Round sẽ áp dụng co tất cả 
- 
# Validate:
- Validate Painting có AwardId và RoundId không cùng trong 1 cuộc thi
- Bắt validate add RoundTOpic ( Add Trùng)
- Bắt validate add PaintingCollection (Add Trùng)
- Chưa bắt validate date contest
- Tên topic khônng trùng nhau
- Validate tuổi khi đăng ký vào contest

# Sửa: 
- Ban/UnBan Account
- Chưa add validate cho RoundTopicdelete

- xem các cuộc thi
- xem chi tiết cuộc thi
- xem các bộ sưu tập
- xem các thí sinh có giải 5 năm gần đây
- Nếu xóa Contest thì status của những bảng liên quan sẽ đổi luôn
- Sửa Output cho GetContestById
- (Xóa Contest sẽ đổi status của những bảng link Contest(Level, Round, Topic, Sponsor
- Chuyển Stauts của report
- Đổi path Get Paintg By Collection(Controller)
- Lấy ra roundid topicid từ roundtopicid trong painting (paiting view model) ( Lấy Round)



  
# Xong :white_check_mark:
- Sửa viewmodel resource lấy các bảng liên quan :white_check_mark:
- Lấy tranh lấy luôn award :white_check_mark:
- Kiếm accountbycode :white_check_mark:
- Generate code account :white_check_mark:
- Generate Code tranh khi tạo (draft or submit) :white_check_mark:
- Get Painting By AccountId :white_check_mark:
- Tạo Round add cho toàn bộ level (thay levelid = contestid) với bỏ listtopic :white_check_mark:
- Add nhiều topicround :white_check_mark:
- get alltopic (không phân trang) :white_check_mark:
