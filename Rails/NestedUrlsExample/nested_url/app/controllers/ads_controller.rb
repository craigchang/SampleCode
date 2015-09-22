class AdsController < ApplicationController
  before_action :set_ad, only: [:show, :edit, :update, :destroy]

  # GET /ads
  # GET /ads.json
  def index
    @magazine = Magazine.find(params[:magazine_id])
    @ads = Ad.all
  end

  # GET /ads/1
  # GET /ads/1.json
  def show
    @magazine = Magazine.find(params[:magazine_id])
  end

  # GET /ads/new
  def new
    #puts params[:magazine_id]
    @magazine = Magazine.find(params[:magazine_id])
    @ad = @magazine.ads.build
  end

  # GET /ads/1/edit
  def edit
    @magazine = Magazine.find(params[:magazine_id])
  end

  # POST /ads
  # POST /ads.json
  def create
    @magazine = Magazine.find(params[:magazine_id])
    @ad = Ad.new(ad_params)

    respond_to do |format|
      if @ad.save
        format.html { redirect_to magazine_ad_url(@magazine, @ad), notice: 'Ad was successfully created.' }
        format.json { render :show, status: :created, location: @ad }
      else
        format.html { render :new }
        format.json { render json: @ad.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /ads/1
  # PATCH/PUT /ads/1.json
  def update
    @magazine = Magazine.find(params[:magazine_id])
    respond_to do |format|
      if @ad.update(ad_params)
        format.html { redirect_to magazine_ad_url(@magazine, @ad), notice: 'Ad was successfully updated.' }
        format.json { render :show, status: :ok, location: @ad }
      else
        format.html { render :edit }
        format.json { render json: @ad.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /ads/1
  # DELETE /ads/1.json
  def destroy
    @ad.destroy
    respond_to do |format|
      format.html { redirect_to ads_url, notice: 'Ad was successfully destroyed.' }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_ad
      @ad = Ad.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def ad_params
      params.require(:ad).permit(:magazine_id, :content)
    end
end
