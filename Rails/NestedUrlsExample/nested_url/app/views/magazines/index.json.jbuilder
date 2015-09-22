json.array!(@magazines) do |magazine|
  json.extract! magazine, :id, :content
  json.url magazine_url(magazine, format: :json)
end
