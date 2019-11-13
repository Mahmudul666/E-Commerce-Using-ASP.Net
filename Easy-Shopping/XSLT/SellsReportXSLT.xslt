<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <div class="main">
      <h2>View Sells Report</h2>
      <xsl:for-each select="tblPurchase/tblPurchase">
        <div class="box">
          <h3>
            <xsl:value-of select="PurchaseID"/>
          </h3>
          <h3>
            <xsl:value-of select="UserID"/>
          </h3>
          <h3>
            <xsl:value-of select="PIDSizeID"/>
          </h3>
          <h3>
            <xsl:value-of select="CartAmount"/>
          </h3>
          <h3>
            <xsl:value-of select="CartDiscount"/>
          </h3>
          <h3>
            <xsl:value-of select="TotalPayed"/>
          </h3>
          <h3>
            <xsl:value-of select="PaymentType"/>
          </h3>
          <h3>
            <xsl:value-of select="PaymentStatus"/>
          </h3>
          <h3>
            <xsl:value-of select="DateOfPurchase"/>
          </h3>
          <h3>
            <xsl:value-of select="Name"/>
          </h3>
          <h3>
            <xsl:value-of select="Address"/>
          </h3>
          <h3>
            <xsl:value-of select="PinCode"/>
          </h3>
          <h3>
            <xsl:value-of select="MobileNumber"/>
          </h3>

          
        </div>
      </xsl:for-each>
    </div>
  </xsl:template>
</xsl:stylesheet>
