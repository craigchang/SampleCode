json.array!(@ads) do |ad|
  json.extract! ad, :id, :magazine_id, :content
  json.url ad_url(ad, format: :json)
end
