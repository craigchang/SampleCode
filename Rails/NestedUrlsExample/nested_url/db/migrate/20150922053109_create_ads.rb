class CreateAds < ActiveRecord::Migration
  def change
    create_table :ads do |t|
      t.references :magazine, index: true, foreign_key: true
      t.string :content

      t.timestamps null: false
    end
  end
end
