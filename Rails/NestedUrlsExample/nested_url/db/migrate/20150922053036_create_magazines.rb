class CreateMagazines < ActiveRecord::Migration
  def change
    create_table :magazines do |t|
      t.string :content

      t.timestamps null: false
    end
  end
end
