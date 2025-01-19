namespace EconChart.Util
{
    public class SqlStatement
    {
        public static string BOKRateKtb3Ktb10 =
            "SELECT a.business_date, " +
            "       b.economic_index AS bok, " +
            "       a.economic_index AS ktb3, " +
            "       e.economic_index AS ktb10 " +
            "FROM ECOS_010200000 a " +
            "     INNER JOIN ECOS_0101000 b ON a.business_date = b.business_date " +
            "     INNER JOIN ECOS_010210000 e ON a.business_date = e.business_date " +
            "ORDER BY 1; " ;

        public static string BokKeyRateKtb10AndDgs10 =
            "select " +
            "a.business_date " +
            ",a.economic_index as bok " +
            ",b.economic_index as ktb10 " +
            ",c.economic_index as dgs10 " +
            "from ECOS_0101000 a " +
            "inner join ECOS_010210000 b on a.business_date = b.business_date " +
            "inner join FRED_DGS10 c on a.business_date = c.business_date " +
            "order by 1 ";

        public static string DffDgs20Dgs30 =
            "SELECT a.business_date, " +
            "       b.economic_index AS dff, " +
            "       a.economic_index AS dgs20, " +
            "       c.economic_index AS dgs30 " +
            "FROM fred_dgs20 a " +
            "     INNER JOIN fred_dff b ON a.business_date = b.business_date " +
            "     LEFT JOIN fred_dgs30 c ON a.business_date = c.business_date " +
            "ORDER BY 1; ";

        public static string DEXKOUS52W =
            "SELECT business_date AS date, " +
            "       economic_index AS kous, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 260 PRECEDING) AS kous52w " +
            "FROM ECOS_0000001 " +
            "WHERE business_date >= '2000-01-01' " +
            "ORDER BY business_date ";

        public static string DXY52W =
            "SELECT business_date AS date, " +
            "       economic_index AS dxy, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 260 PRECEDING) AS dxy52w " +
            "FROM YAHOO_DXY " +
            "WHERE business_date >= '2000-01-01' " +
            "ORDER BY business_date ";

        public static string DOLLARGAPINDEX =
            "SELECT a.business_date AS date, " +
            "       (a.economic_index / b.economic_index) * 100 AS dgap, " +
            "       avg ((a.economic_index / b.economic_index) * 100) " +
            "          OVER (ORDER BY a.business_date ROWS 260 PRECEDING) AS dgap52w " +
            "FROM YAHOO_DXY a " +
            "     INNER JOIN ECOS_0000001 b ON a.business_date = b.business_date " +
            "WHERE a.business_date >= '2000-01-01' " +
            "ORDER BY a.business_date ";

        // 이머징 마켙 회사채-미국 회사채, 원달러
        public static string FredBamlSpread1DexKoUs =
            "select " +
            " a.business_date " +
            " ,a.economic_index-b.economic_index as spread " +
            " ,c.economic_index " +
            " from FRED_BAMLEMCBPIOAS a " +
            " inner join FRED_BAMLC0A0CM b on a.business_date=b.business_date " +
            " left join ECOS_0000001 c on a.business_date=c.business_date " +
            " order by a.business_date ";

        // 이머징 아시아 마켙 회사채-미국 회사채, 원달러
        public static string FredBamlSpread2DexKoUs =
            "select " +
            " a.business_date " +
            " ,a.economic_index-b.economic_index as spread " +
            " ,c.economic_index " +
            " from FRED_BAMLEMRACRPIASIAOAS a " +
            " inner join FRED_BAMLC0A0CM b on a.business_date=b.business_date " +
            " left join ECOS_0000001 c on a.business_date=c.business_date " +
            " order by a.business_date ";

        public static string YahooSectorEtfXLF =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
            "          sma50, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM YAHOO_XLF " +
            "ORDER BY business_date ";

        public static string YahooSectorEtfXLE =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLE " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLU =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLU " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLP =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLP " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLY =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLY " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLI =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLI " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLB =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLB " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLV =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLV " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLK =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLK " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLC =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLC " +
                    "ORDER BY business_date ";

        public static string YahooSectorEtfXLRE =
                    "SELECT business_date, " +
                    "       economic_index, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
                    "          sma50, " +
                    "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
                    "          sma200 " +
                    "  FROM YAHOO_XLRE " +
                    "ORDER BY business_date ";

        public static string YahooDollarIndex =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 49 PRECEDING) " +
            "          sma50, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM YAHOO_DXY " +
            "ORDER BY business_date ";

        public static string YahooDollarIndexAndKRW =
            "select a.business_date " +
            ", a.economic_index as krw " +
            ", b.economic_index as dxy " +
            "from ECOS_0000001 a " +
            "inner join YAHOO_DXY b on a.business_date= b.business_date " +
            "where a.business_date > '1998-01-01' " +
            "order by business_date desc ";

        // Wilshire 5000 Total Market Full Cap Index
        public static string Wilshire5000Index =
            "select " +
            "business_date " +
            ",economic_index " +
            ",log(economic_index) as log " +
            "from FRED_WILL5000INDFC " +
            "order by business_date ";

        // S&P 500
        public static string SnP500Index =
            "select " +
            "business_date " +
            //",economic_index " +
            ",cast(log(ECONOMIC_INDEX) as decimal(30,4)) " +
            "from FRED_SP500 " +
            "order by business_date ";

        // NASDAQ Composite Index
        public static string NasdaqCompoIndex =
            "select " +
            "business_date " +
            ",cast(log(ECONOMIC_INDEX) as decimal(30,4)) " +
            "from FRED_NASDAQCOM " +
            "order by business_date ";

        // Dow Jones Transportation Average
        public static string DowJonesTransIndex =
            "select " +
            "business_date " +
            ",economic_index " +
            ",log(economic_index) as log " +
            "from FRED_DJTA " +
            "order by business_date ";

        // Dow Jones Industrial Average
        public static string DowJonesIndex =
            "select " +
            "business_date " +
            ",cast(log(ECONOMIC_INDEX) as decimal(30,4)) " +
            "from FRED_DJIA " +
            "order by business_date ";

        // Crude Oil Prices: West Texas Intermediate (WTI) - Cushing, Oklahoma
        public static string WtiAndOilVix =
            "select " +
            "a.business_date " +
            ",a.economic_index as wti " +
            ",b.economic_index as oilvix " +
            "from FRED_DCOILWTICO a " +
            "left join FRED_OVXCLS b on a.business_date=b.business_date " +
            "order by a.business_date ";

        //VIX and SP500 
        public static string VixVsSp500Day =
            "select  " +
            "a.business_date " +
            ",a.economic_index as vix " +
            ",b.economic_index as sp500 " +
            "from FRED_VIXCLS a " +
            "inner join FRED_SP500 b on a.business_date=b.business_date " +
            "order by a.business_date ";

        //VIX 3mo and SP500 
        public static string Vix3moVsSp500Day =
            "select  " +
            "a.business_date " +
            ",a.economic_index as vxv " +
            ",b.economic_index as sp500 " +
            "from FRED_VXVCLS a " +
            "inner join FRED_SP500 b on a.business_date=b.business_date " +
            "order by a.business_date ";

        //VIX and DGS10
        public static string VixVsDgs10 =
            "select  " +
            "a.business_date " +
            ",a.economic_index as vxt " +
            ",b.economic_index as dgs10 " +
            "from FRED_VXTYN a " +
            "inner join FRED_DGS10 b on a.business_date=b.business_date " +
            "order by a.business_date ";

        //VIX and WTI
        public static string VixVsWti =
            "select  " +
            "a.business_date " +
            ",a.economic_index as ovx " +
            ",b.economic_index as wti " +
            "from FRED_OVXCLS a " +
            "inner join FRED_DCOILWTICO b on a.business_date=b.business_date " +
            "order by a.business_date ";



        // 미국채 10년물, 한국채 10년물 일간 동향
        public static string UsGB10YvsKrGB10Y =
            "SELECT " +
            "a.business_date  " +
            ",a.economic_index KB10 " +
            ",b.economic_index EB10 " +
            ",a.economic_index-b.economic_index SPREAD " +
            "from ECOS_010210000 a " +
            "inner join FRED_DGS10 b on a.business_date=b.business_date " +
            "ORDER BY business_date ";

        // 미국채 10년물 일간 동향
        public static string UsGB10YSMA =
            "SELECT " +
            "business_date  " +
            ",economic_index " +
            ",avg (economic_index) OVER (ORDER BY business_date ROWS 19 PRECEDING) sma20 " +
            ",avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) sma60 " +
            ",avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) sma200 " +
            "FROM FRED_DGS10 " +
            "ORDER BY business_date ";


        // 최근 갱신 씨리즈 정보
        public static string RecentlyUpdatedList =
            "SELECT id," +
            "       ename," +
            "       kname," +
            "       units," +
            "       freq," +
            "       sa," +
            "       sfdate," +
            "       sldate," +
            "       upt_date" +
            "  FROM INDEX_INFO" +
            " WHERE     diss = 0" +
            "       AND delete_yn = 0" +
            "       AND upt_date >= DATEADD (day, -1, CAST (GETDATE () AS DATE))" +
            "ORDER BY upt_date DESC";
        // 
        public static string KrKeyRateAndUsFfrSpreadVsDexKoUs =
        "select " +
        "a.business_date " +
        ",a.economic_index " +
        ",b.spread " +
        "from ECOS_0000001 a " +
        "left join ( " +
        "select  " +
        " a.business_date " +
        " ,a.economic_index - b.economic_index as spread " +
        "from ECOS_0101000 a  " +
        "inner join FRED_DFF b on a.business_date = b.business_date " +
        ") b on a.business_date = b.business_date " +
        "where a.business_date >= '1999-05-06' " +
        "order by a.business_date ";

        // 
        public static string KrKeyRateAndUsFFR =
        "select " +
        " a.business_date " +
        " ,a.economic_index as krrate " +
        " ,b.economic_index as usrate " +
        " from ECOS_0101000 a " +
        " left join FRED_DFF b on a.business_date = b.business_date " +
        " order by a.business_date ";

        // 미국 재무부 채권 정보 (1달)
        public static string RecentlyUSTreasList =
            "SELECT business_date, " +
            "       gs1mo, " +
            "       gs2mo, " +
            "       gs3mo, " +
            "       gs6mo, " +
            "       gs1, " +
            "       gs2, " +
            "       gs3, " +
            "       gs5, " +
            "       gs7, " +
            "       gs10, " +
            "       gs20, " +
            "       gs30 " +
            "FROM USTREAS_GS " +
            "WHERE business_date >= DATEADD (day, -50, CAST (GETDATE () AS DATE)) " +
            "ORDER BY business_date DESC ";

        // 미국 재무부 인플레이션 채권 정보



        #region ETC
        //KoUsJp2yrSpread
        public static string KoUsJp2yrSpread =
            "SELECT a.business_date " +
            "      ,a.economic_index - b.economic_index kojp " +
            "      ,c.economic_index - b.economic_index usjp " +
            "FROM ECOS_010400002 a " +
            "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_2Y b " +
            "        ON a.business_date = b.business_date " +
            "     INNER JOIN fred_dgs2 c ON a.business_date = c.business_date " +
            "ORDER BY a.business_date";

        //KoKtb3Msb2SpreadDexkous
        public static string KoKtb3Msb2SpreadDexkous =
            "SELECT a.business_date " +
        "      ,a.economic_index - b.economic_index spread " +
        "      ,c.economic_index " +
        "FROM ECOS_010200000 a " +
        "     INNER JOIN ECOS_010400002 b ON a.business_date = b.business_date " +
        "     INNER JOIN ECOS_0000001 c ON a.business_date = c.business_date " +
        "ORDER BY a.business_date";

        // UsJpBond2ySpreadAndYenDollar
        public static string UsJpBond2ySpreadAndYenDollar =
            "SELECT a.business_date " +
            "      ,b.economic_index - a.economic_index spread " +
            "      ,c.economic_index " +
            "FROM QUANDL_INTEREST_RATE_JAPAN_2Y a " +
            "     INNER JOIN FRED_DGS2 b ON a.business_date = b.business_date " +
            "     LEFT JOIN FRED_DEXJPUS c ON a.business_date = c.business_date " +
            "ORDER BY a.business_date";

        public static string MoveAndDexkous =
            "select " +
            "a.business_date " +
            ",a.economic_index as move " +
            ",b.economic_index as dexkous " +
            "from yahoo_move a " +
            "inner join ECOS_0000001 b on a.business_date = b.business_date " +
            "order by 1 " +
            "; ";

        public static string MoveAndKtb10 =
            "select " +
            "a.business_date " +
            ",a.economic_index as move " +
            ",b.economic_index as ktb10 " +
            "from yahoo_move a " +
            "inner join ECOS_010210000 b on a.business_date = b.business_date " +
            "order by 1 " +
            "; ";

        public static string MoveAndDgs10 =
            "select " +
            "a.business_date " +
            ",a.economic_index as move " +
            ",b.economic_index as dgs10 " +
            "from yahoo_move a " +
            "inner join FRED_DGS10 b on a.business_date = b.business_date " +
            "order by 1 " +
            "; ";


        // BAML Risk Taking 
        public static string BofAMerrillLynchOptionAdjustedSpread =
            "SELECT a.business_date," +
            "       a.economic_index," +
            "       b.economic_index," +
            "       c.economic_index," +
            "       d.economic_index," +
            "       e.economic_index" +
            "  FROM FRED_BAMLC0A0CM a" +
            "       INNER JOIN FRED_BAMLHE00EHYIOAS b ON a.business_date = b.business_date" +
            "       INNER JOIN FRED_BAMLH0A0HYM2 c ON a.business_date = c.business_date" +
            "       INNER JOIN FRED_BAMLEMRACRPIASIAOAS d" +
            "          ON a.business_date = d.business_date" +
            "       INNER JOIN FRED_BAMLEMCBPIOAS e ON a.business_date = e.business_date" +
            " ORDER BY a.business_date";

        //
        public static string KospiAndSnp =
            "select " +
            "a.business_date " +
            ",a.economic_index as kospi " +
            ",b.economic_index as snp " +
            "from ECOS_0001000 a " +
            "inner join FRED_SP500 b on a.business_date = b.business_date " +
            "order by a.business_date";

        // 일간 원/달러, 엔/달러, 원/엔 재정환율
        public static string DexKoUs_JpUs_KoJp =
            "SELECT a.business_date, " +
            "       a.economic_index wonyen, " +
            "       b.economic_index jpus, " +
            "       c.economic_index kous " +
            "  FROM ECOS_0000002 a " +
            "       LEFT JOIN FRED_DEXJPUS b ON a.business_date = b.business_date " +
            "       LEFT JOIN ECOS_0000001 c ON a.business_date = c.business_date " +
            " WHERE a.business_date >= '1990-01-01' " +
            "ORDER BY 1 ";

        // 외국인 거래소 순매수 잠정치 60, 200 SMA
        public static string ForeignKospiBuySell =
            "SELECT business_date,        " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0030000 " +
            "ORDER BY business_date ";


        // 외국인 코스닥 순매수 잠정치 60, 200 SMA
        public static string ForeignKosdaqBuySell =
            "SELECT business_date,        " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0113000 " +
            "ORDER BY business_date ";

        // 수출 3개월, PCYA
        public static string EcosExport3SmaPcya =
            "SELECT " +
            "business_date " +
            ",AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3 " +
            ",( (economic_index / LAG (economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100 pcya " +
            "FROM ECOS_FIEE  " +
            "ORDER BY business_date ";


        // 수입 3개월, PCYA
        public static string EcosImport3SmaPcya =
            "SELECT " +
            "business_date " +
            ",AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3 " +
            ",( (economic_index / LAG (economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100 pcya " +
            "FROM ECOS_FIEF  " +
            "ORDER BY business_date ";

        // 비거주자 예수금: 원화예금 3개월, PCYA
        public static string NonResidentWonDeposit3SmaPcya =
            "SELECT " +
            "business_date " +
            ",AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3 " +
            ",( (economic_index / LAG (economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100 pcya " +
            "FROM ECOS_BCB901  " +
            "ORDER BY business_date ";

        // 비거주자 예수금: 외화예금 3개월, PCYA
        public static string NonResidentExDeposit3SmaPcya =
            "SELECT " +
            "business_date " +
            ",AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3 " +
            ",( (economic_index / LAG (economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100 pcya " +
            "FROM ECOS_BCB902  " +
            "ORDER BY business_date ";

        // 대출/수신금리 및 순이자 마진(NIM) 
        public static string EcosLoanReceiveNim =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index spread, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_BECBLA01 a " +
            "       INNER JOIN ECOS_BEABAA2 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 외국인 거래소 순매수 잠정치와 KOSPI
        // YAHOO_@KS11 => ECOS_0001000
        public static string YahooKospiAndEcosForeignKospiBuySell =
            "SELECT a.business_date, " +
            "       b.economic_index, " +
            "       a.economic_index " +
            "  FROM ECOS_0030000 a " +
            "       INNER JOIN ECOS_0001000 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 외국인 KOSDAQ 순매수 잠정치와 KOSDAQ
        // YAHOO_@KQ11 => ECOS_0089000
        public static string YahooKosdaqAndEcosForeignKosdaqBuySell =
            "SELECT a.business_date, " +
            "       b.economic_index, " +
            "       a.economic_index " +
            "  FROM ECOS_0113000 a " +
            "       INNER JOIN ECOS_0089000 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 KOSPI 달러 환산 동향
        // YAHOO_@KS11 => ECOS_0001000
        public static string YahooKospiAndEcosDexKoUs =
            "select " +
            "a.business_date " +
            ",(a.economic_index/(1/b.economic_index)) tokous " +
            ",avg ((a.economic_index/(1/b.economic_index))) OVER (ORDER BY a.business_date ROWS 59 PRECEDING) sma60 " +
            ",avg ((a.economic_index/(1/b.economic_index))) OVER (ORDER BY a.business_date ROWS 199 PRECEDING) sma200 " +
            "from ECOS_0001000 a " +
            "inner join ECOS_0000001 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        #endregion

        #region ecos interest rate
        //일간 콜금리(익일물, 중개회사거래)
        public static string EcosCallRate =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010102000 a " +
            "       INNER JOIN FRED_DFF b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 ECOS 채권 동향
        public static string EcosKtbStatus =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index, " +
            "       c.economic_index, " +
            "       d.economic_index, " +
            "       e.economic_index, " +
            "       f.economic_index, " +
            "       g.economic_index, " +
            "       h.economic_index " +
            "  FROM ECOS_010502000 a " +
            "       LEFT JOIN ECOS_010190000 b ON a.business_date = b.business_date " +
            "       LEFT JOIN ECOS_010200000 c ON a.business_date = c.business_date " +
            "       LEFT JOIN ECOS_010200001 d ON a.business_date = d.business_date " +
            "       LEFT JOIN ECOS_010210000 e ON a.business_date = e.business_date " +
            "       LEFT JOIN ECOS_010220000 f ON a.business_date = f.business_date " +
            "       LEFT JOIN ECOS_010230000 g ON a.business_date = g.business_date " +
            "       LEFT JOIN ECOS_010102000 h ON a.business_date = h.business_date " +
            " WHERE a.business_date >= '2000-02-01' " +
            "ORDER BY a.business_date ";

        //일간 KORIBOR(3개월)
        public static string EcosKoribor3M =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010150000 a " +
            "       INNER JOIN FRED_USD3MTD156N b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 KORIBOR(6개월)
        public static string EcosKoribor6M =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010151000 a " +
            "       INNER JOIN FRED_USD6MTD156N b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 KORIBOR(12개월)
        public static string EcosKoribor12M =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010152000 a " +
            "       INNER JOIN FRED_USD12MD156N b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 CD(91일)
        public static string EcosCd91D =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010502000 a " +
            "       INNER JOIN FRED_DGS3MO b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 통안증권(91일물)
        public static string EcosMsb91D =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010400001 a " +
            "       INNER JOIN FRED_DGS3MO b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(1년)
        public static string EcosKtb1Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010190000 a " +
            "       INNER JOIN FRED_DGS1 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //
        public static string DxyAndFedFundRate =
        "select  " +
        "a.business_date " +
        ",a.economic_index as dxy " +
        ",b.economic_index as dff " +
        "from YAHOO_DXY a " +
        "inner join FRED_DFF b on a.business_date = b.business_date " +
        "order by a.business_date ";

        //일간 국고채(3년)
        public static string EcosKtb3Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM ECOS_010200000 a " +
            "       INNER JOIN FRED_DGS3 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(5년)
        public static string EcosKtb5Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010200001 a " +
            "       INNER JOIN FRED_DGS5 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(10년)
        public static string EcosKtb10Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM ECOS_010210000 a " +
            "       INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(20년)
        public static string EcosKtb20Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010220000 a " +
            "       INNER JOIN FRED_DGS20 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(30년)
        public static string EcosKtb30Y =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010230000 a " +
            "       INNER JOIN FRED_DGS30 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 국고채(3년), 국고채(10년), 스프레드
        public static string EcosKtb3YKtb10YSpread =
            "SELECT a.business_date, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM ECOS_010210000 a " +
            "       INNER JOIN ECOS_010200000 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //월간 독일 10년물, 미국채 10년물, 스프레드
        public static string EcosBund10YDgs10YSpread =
            " SELECT a.business_date," +
            "        a.economic_index," +
            "        b.economic_index," +
            "        b.economic_index - a.economic_index spread" +
            "   FROM ECOS_1030101 a" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                AVG (economic_index) economic_index" +
            "           FROM FRED_DGS10" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        b" +
            "           ON a.business_date = b.business_date" +
            " ORDER BY a.business_date";

        // CD금리와 미국채 3개월물 동향
        public static string Ecos90DDgs3MoSpread =
            "select " +
            "k.business_date " +
            ",k.economic_index ko " +
            ",a.economic_index us " +
            ",k.economic_index-a.economic_index spread " +
            "from ECOS_010502000 k " +
            "inner join FRED_DGS3MO a on k.business_date=a.business_date " +
            "order by k.business_date ";

        //월간 영국 10년물, 미국채 10년물, 스프레드
        public static string EcosEgb10YDgs10YSpread =
            " SELECT a.business_date," +
            "        a.economic_index," +
            "        b.economic_index," +
            "        b.economic_index - a.economic_index spread" +
            "   FROM ECOS_1030201 a" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                AVG (economic_index) economic_index" +
            "           FROM FRED_DGS10" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        b" +
            "           ON a.business_date = b.business_date" +
            " ORDER BY a.business_date";

        //월간 일본 10년물, 미국채 10년물, 스프레드
        public static string EcosJgb10YDgs10YSpread =
            " SELECT a.business_date," +
            "        a.economic_index," +
            "        b.economic_index," +
            "        b.economic_index - a.economic_index spread" +
            "   FROM ECOS_1030301 a" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                AVG (economic_index) economic_index" +
            "           FROM FRED_DGS10" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        b" +
            "           ON a.business_date = b.business_date" +
            " ORDER BY a.business_date";


        // 국고채 3년물-회사채(3년,AA-) 스프레드
        public static string EcosKtb3Cb3aaSpread =
            "select " +
            "a.business_date " +
            ",b.economic_index-a.economic_index spread " +
            "from ECOS_010200000 a " +
            "inner join ECOS_010300000 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // 국고채 3년물-회사채(3년)(BBB-) 스프레드
        public static string EcosKtb3Cb3bbbSpread =
            "select " +
            "a.business_date " +
            ",b.economic_index-a.economic_index spread " +
            "from ECOS_010200000 a " +
            "inner join ECOS_010320000 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // 국고채 5년물-회사채(3년,AA-) 스프레드
        public static string EcosKtb5Cb3aaSpread =
            "select " +
            "a.business_date " +
            ",b.economic_index-a.economic_index spread " +
            "from ECOS_010200001 a " +
            "inner join ECOS_010300000 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // 국고채 5년물-회사채(3년)(BBB-) 스프레드
        public static string EcosKtb5Cb3bbbSpread =
            "select " +
            "a.business_date " +
            ",b.economic_index-a.economic_index spread " +
            "from ECOS_010200001 a " +
            "inner join ECOS_010320000 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // 국고채 3년물-콜금리 스프레드
        public static string EcosKtb3CallSpread =
            "select " +
            "a.business_date " +
            ",a.economic_index-b.economic_index spread " +
            "from ECOS_010200000 a  " +
            "inner join ECOS_010102000 b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // KOSPI 와 미국채 10년물 동향
        public static string EcosKospiAndDgs10 =
            "select " +
            " a.business_date " +
            " ,a.economic_index " +
            " ,b.economic_index " +
            "from ECOS_0001000 a " +
            "left join FRED_DGS10 b on a.business_date = b.business_date " +
            "order by a.business_date ";



        #endregion

        #region ecos exchange rate
        // 원/달러, 자유 변동환율제만 반영 (1998-01-01 ~ )
        public static string EcosDexKoUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000001 " +
            " WHERE business_date >= '1998-01-01' " +
            "ORDER BY business_date ";

        // 원/100엔, 원화 자유 변동환율제만 반영 (1998-01-01 ~ )
        public static string EcosDexKoJp =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000002 " +
            " WHERE business_date >= '1998-01-01' " +
            "ORDER BY business_date ";

        // 원/유로
        public static string EcosDexKoEu =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000003 " +
            "ORDER BY business_date ";

        // 원/영국 파운드
        public static string EcosDexKoUk =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000012 " +
            "ORDER BY business_date ";

        // 원/캐나다 달러
        public static string EcosDexKoCa =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000013 " +
            "ORDER BY business_date ";

        // 원/스위스 프랑
        public static string EcosDexKoSz =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000014 " +
            "ORDER BY business_date ";

        // 원/스웨덴 크로나
        public static string EcosDexKoSd =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000016 " +
            "ORDER BY business_date ";

        // 원/호주 달러
        public static string EcosDexKoAl =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000017 " +
            "ORDER BY business_date ";

        // 원/싱가폴 달러
        public static string EcosDexKoSi =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000024 " +
            "ORDER BY business_date ";

        // 원/말레이지아 링기트
        public static string EcosDexKoMa =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000025 " +
            "ORDER BY business_date ";

        // 원/뉴질랜드 달러
        public static string EcosDexKoNz =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000026 " +
            "ORDER BY business_date ";

        // 원/태국 바트
        public static string EcosDexKoTh =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000028 " +
            "ORDER BY business_date ";

        // 원/대만 달러
        public static string EcosDexKoTa =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000031 " +
            "ORDER BY business_date ";

        // 원/필리핀 페소
        public static string EcosDexKoPh =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000034 " +
            "ORDER BY business_date ";

        // 원/인도네시아 루피아(100루피아)
        public static string EcosDexKoId =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000029 " +
            "ORDER BY business_date ";

        // 원/베트남 동
        public static string EcosDexKoVn =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000035 " +
            "ORDER BY business_date ";

        // 원/인도 루피
        public static string EcosDexKoIn =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000037 " +
            "ORDER BY business_date ";

        // 원/멕시코 페소
        public static string EcosDexKoMx =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000040 " +
            "ORDER BY business_date ";

        // 원/브라질 헤알
        public static string EcosDexKoBr =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000041 " +
            "ORDER BY business_date ";

        // 원/아르헨티나 페소
        public static string EcosDexKoAr =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000042 " +
            "ORDER BY business_date ";

        // 원/러시아 루블
        public static string EcosDexKoRu =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000043 " +
            "ORDER BY business_date ";

        // 원/터키 리라
        public static string EcosDexKoTr =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000050 " +
            "ORDER BY business_date ";

        // 원/남아프리카공화국 랜드
        public static string EcosDexKoZa =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000051 " +
            "ORDER BY business_date ";

        // 원/위안(매매기준율)
        public static string EcosDexKoCn =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM ECOS_0000053 " +
            "ORDER BY business_date ";

        // 원/달러 환율과 외국인 거래소 순매수 90일 이동평균
        public static string EcosDexKoUsAndBuySell90Sma =
            "SELECT a.business_date, " +
            "       avg (a.economic_index) " +
            "          OVER (ORDER BY a.business_date ROWS 89 PRECEDING), " +
            "       avg (b.economic_index) " +
            "          OVER (ORDER BY a.business_date ROWS 89 PRECEDING) " +
            "  FROM ECOS_0000001 a " +
            "       LEFT JOIN ECOS_0030000 b ON a.business_date = b.business_date " +
            " WHERE a.business_date >= '2003-01-02' " +
            "ORDER BY a.business_date ";

        // 월간 미일 CD금리차, 한미 CD금리차, 원엔 재정환율
        // ECOS 소스 변경으로 인하여 일본과 미국의 CD금리를 라이보 3개월로 변경함.
        public static string CdSpreadJpUsAndKoUs =
            //"SELECT a.business_date," +
            //"       b.economic_index - a.economic_index spread_jpus," +
            //"       c.economic_index - b.economic_index spread_kous," +
            //"       d.economic_index wonyen" +
            //"  FROM ecos_cdjpn a" +
            //"       INNER JOIN ECOS_CDUSA b ON a.business_date = b.business_date" +
            //"       INNER JOIN" +
            //"       (SELECT CONVERT (DATE," +
            //"                        concat (format (business_date, 'yyyy-MM'), '-01'))" +
            //"                  business_date," +
            //"               avg (economic_index) economic_index" +
            //"          FROM ECOS_010502000" +
            //"        GROUP BY CONVERT (DATE," +
            //"                          concat (format (business_date, 'yyyy-MM'), '-01')))" +
            //"       c" +
            //"          ON a.business_date = c.business_date" +
            //"       INNER JOIN" +
            //"       (SELECT CONVERT (DATE," +
            //"                        concat (format (business_date, 'yyyy-MM'), '-01'))" +
            //"                  business_date," +
            //"               avg (economic_index) economic_index" +
            //"          FROM ECOS_0000002" +
            //"        GROUP BY CONVERT (DATE," +
            //"                          concat (format (business_date, 'yyyy-MM'), '-01')))" +
            //"       d" +
            //"          ON a.business_date = d.business_date" +
            //"  ORDER BY a.business_date";
            " SELECT a.business_date," +
            "        c.economic_index - b.economic_index spread_jpus," +
            "        a.economic_index - c.economic_index spread_kous," +
            "        d.economic_index wonyen" +
            "   FROM (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                avg (economic_index) economic_index" +
            "           FROM ECOS_010502000" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        a" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                avg (economic_index) economic_index" +
            "           FROM FRED_JPY3MTD156N" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        b" +
            "           ON a.business_date = b.business_date" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                avg (economic_index) economic_index" +
            "           FROM FRED_USD3MTD156N" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        c" +
            "           ON a.business_date = c.business_date" +
            "        INNER JOIN" +
            "        (SELECT CONVERT (DATE," +
            "                         concat (format (business_date, 'yyyy-MM'), '-01'))" +
            "                   business_date," +
            "                avg (economic_index) economic_index" +
            "           FROM ECOS_0000002" +
            "         GROUP BY CONVERT (DATE," +
            "                           concat (format (business_date, 'yyyy-MM'), '-01')))" +
            "        d" +
            "           ON a.business_date = d.business_date" +
            " ORDER BY a.business_date";

        // 원/달러, BofA Merrill Lynch Asia Emerging Markets Corporate Plus Sub-Index Option-Adjusted Spreadⓒ
        public static string EcosDexKoUsAndAsiaEmergingMarketsCorporatePlusSubIndex =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM FRED_BAMLEMRACRPIASIAOAS a " +
            "       INNER JOIN ECOS_0000001 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // 일간 원/달러, WTI
        public static string EcosDexKoUsAndWti =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM ECOS_0000001 a " +
            "       LEFT JOIN FRED_DCOILWTICO b ON a.business_date = b.business_date " +
            " WHERE a.business_date>='1998-01-01' " +
            "ORDER BY a.business_date ";

        // 일간 원/달러, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
        public static string EcosDexKoUsAndTwExo =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM ECOS_0000001 a " +
            "       LEFT JOIN FRED_DTWEXO b ON a.business_date = b.business_date " +
            " WHERE a.business_date>='1998-01-01' " +
            "ORDER BY a.business_date ";

        // 10y-2y and 10y-3mo spread
        public static string EcosCycleSpread =
            "select " +
            "a.business_date " +
            ",a.economic_index-b.economic_index spread10y2y " +
            ",a.economic_index-c.economic_index spread10y3m " +
            "from ECOS_010210000 a " +
            "inner join ECOS_010400002 b on a.business_date = b.business_date " +
            "inner join ECOS_010502000 c on a.business_date = c.business_date " +
            "order by 1 ";

        public static string Ktb10AndGs10AndKRW =
            " select " +
            " a.business_date " +
            " ,a.economic_index as kb10 " +
            " ,b.economic_index as gs10 " +
            " ,c.economic_index as krw " +
            " from ECOS_010210000 a " +
            " inner join fred_dgs10 b on a.business_date=b.business_date " +
            " inner join ECOS_0000001 c on a.business_date=c.business_date " +
            " order by a.business_date ";

        #endregion

        #region fred exchange rate
        // Brazil / U.S. Foreign Exchange Rate
        public static string FredDexBzUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXBZUS " +
            "ORDER BY business_date ";

        // Canada / U.S. Foreign Exchange Rate
        public static string FredDexCaUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXCAUS " +
            "ORDER BY business_date ";

        // China / U.S. Foreign Exchange Rate
        public static string FredDexChUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXCHUS " +
            "ORDER BY business_date ";

        // India / U.S. Foreign Exchange Rate
        public static string FredDexInUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXINUS " +
            "ORDER BY business_date ";

        // Japan / U.S. Foreign Exchange Rate
        public static string FredDexJpUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXJPUS " +
            "ORDER BY business_date ";

        // South Korea / U.S. Foreign Exchange Rate
        public static string FredDexKoUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXKOUS " +
            "ORDER BY business_date ";

        // Malaysia / U.S. Foreign Exchange Rate
        public static string FredDexMaUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXMAUS " +
            "ORDER BY business_date ";

        // Mexico / U.S.Foreign Exchange Rate
        public static string FredDexMxUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXMXUS " +
            "ORDER BY business_date ";

        // Sweden / U.S. Foreign Exchange Rate
        public static string FredDexSdUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXSDUS " +
            "ORDER BY business_date ";

        // South Africa / U.S. Foreign Exchange Rate
        public static string FredDexSfUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXSFUS " +
            "ORDER BY business_date ";

        // Singapore / U.S. Foreign Exchange Rate
        public static string FredDexSiUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXSIUS " +
            "ORDER BY business_date ";

        // Switzerland / U.S. Foreign Exchange Rate
        public static string FredDexSzUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXSZUS " +
            "ORDER BY business_date ";

        // Taiwan / U.S. Foreign Exchange Rate
        public static string FredDexTaUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXTAUS " +
            "ORDER BY business_date ";

        // Thailand / U.S. Foreign Exchange Rate
        public static string FredDexThUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXTHUS " +
            "ORDER BY business_date ";

        // U.S. / Australia Foreign Exchange Rate
        public static string FredDexUsAl =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXUSAL " +
            "ORDER BY business_date ";

        // U.S. / Euro Foreign Exchange Rate
        public static string FredDexUsEu =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXUSEU " +
            "ORDER BY business_date ";

        // U.S. / New Zealand Foreign Exchange Rate
        public static string FredDexUsNz =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXUSNZ " +
            "ORDER BY business_date ";

        // U.S. / U.K. Foreign Exchange Rate
        public static string FredDexUsUk =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXUSUK " +
            "ORDER BY business_date ";

        // Venezuela / U.S. Foreign Exchange Rate
        public static string FredDexVzUs =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DEXVZUS " +
            "ORDER BY business_date ";

        // Trade Weighted U.S. Dollar Index: Broad(Euro Area, Canada, Japan, Mexico, China, United Kingdom, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Switzerland, Thailand, Philippines, Australia, Indonesia, India, Israel, Saudi Arabia, Russia, Sweden, Argentina, Venezuela, Chile, Colombia)
        public static string FredDtwExb =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DTWEXB " +
            "ORDER BY business_date ";

        // Trade Weighted U.S. Dollar Index: Major Currencies(Euro Area, Canada, Japan, United Kingdom, Switzerland, Australia, Sweden)
        public static string FredDtwExm =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DTWEXM " +
            "ORDER BY business_date ";

        // Trade Weighted U.S. Dollar Index: Other Important Trading Partners(Mexico, China, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Thailand, Philippines, Indonesia, India, Israel, Saudi Arabia, Russia, Argentina, Venezuela, Chile, Colombia)
        public static string FredDtwExo =
            "SELECT business_date, " +
            "       economic_index, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 59 PRECEDING) " +
            "          sma60, " +
            "       avg (economic_index) OVER (ORDER BY business_date ROWS 199 PRECEDING) " +
            "          sma200 " +
            "  FROM FRED_DTWEXO " +
            "ORDER BY business_date ";

        // 일간 WTI, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
        public static string FredWtiAndTwExo =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index " +
            "  FROM FRED_DCOILWTICO a " +
            "       INNER JOIN FRED_DTWEXO b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Brazil, DEXBZUS
        public static string FredEffExBzEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexbzus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbbrbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Canada, DEXCAUS
        public static string FredEffExCaEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexcaus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbcabis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for China, DEXCHUS
        public static string FredEffExChEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexchus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbcnbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for India, DEXINUS
        public static string FredEffExInEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexinus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbinbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Japan, DEXJPUS
        public static string FredEffExJpEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexjpus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbjpbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Korea, DEXKOUS
        public static string FredEffExKoEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexkous " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbkrbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Malaysia, DEXMAUS
        public static string FredEffExMaEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexmaus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbmybis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Mexico, DEXMXUS
        public static string FredEffExMxEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexmxus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbmxbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //
        // BIS Real Broad Effective Exchange Rate for Sweden, DEXSDUS
        public static string FredEffExSdEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexsdus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbsebis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for South Africa, DEXSFUS
        public static string FredEffExSfEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexsfus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbzabis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Singapore, DEXSIUS
        public static string FredEffExSiEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexsius " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbsgbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Switzerland, DEXSZUS
        public static string FredEffExSzEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexszus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbchbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Taiwan, DEXTAUS
        public static string FredEffExTaEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dextaus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbtwbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Thailand, DEXTHUS
        public static string FredEffExThEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexthus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbthbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Australia, DEXUSAL
        public static string FredEffExAlEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexusal " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbaubis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Euro, DEXUSEU
        public static string FredEffExEuEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexuseu " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbxmbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for New Zealand, DEXUSNZ
        public static string FredEffExNzEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexusnz " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbnzbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for U.K., DEXUSUK
        public static string FredEffExUkEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexusuk " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbgbbis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        // BIS Real Broad Effective Exchange Rate for Venezuela, DEXVZUS
        public static string FredEffExVzEx =
            "SELECT a.business_date, a.economic_index, b.economic_index " +
            "  FROM (SELECT CONVERT (DATE, " +
            "                        concat (format (business_date, 'yyyy-MM'), '-01')) " +
            "                  business_date, " +
            "               avg (economic_index) economic_index " +
            "          FROM fred_dexvzus " +
            "         WHERE business_date >= '1994-01-01' " +
            "        GROUP BY CONVERT (DATE, " +
            "                          concat (format (business_date, 'yyyy-MM'), '-01'))) " +
            "       a " +
            "       LEFT JOIN fred_rbvebis b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";


        #endregion

        #region fred interest rate
        // UsTreasSimple
        public static string UsTreasSimple =
            "SELECT BUSINESS_DATE, " +
            "       gs3mo, " +
            "       gs2, " +
            "       gs10 " +
            "FROM USTREAS_GS " +
            "ORDER BY BUSINESS_DATE ";

        //
        public static string FedFundRate =
            "SELECT business_date, economic_index " +
            "FROM fred_dff " +
            "ORDER BY business_date ";

        //
        public static string FedFundRateDgs2AndDgs10 =
            "SELECT a.business_date, " +
            "       a.economic_index dff, " +
            "       b.ECONOMIC_INDEX dgs2, " +
            "       c.ECONOMIC_INDEX dgs10 " +
            "FROM fred_dff a " +
            "     INNER JOIN fred_dgs2 b ON a.BUSINESS_DATE = b.BUSINESS_DATE " +
            "     INNER JOIN fred_dgs10 c ON a.BUSINESS_DATE = c.BUSINESS_DATE " +
            "ORDER BY a.business_date; ";



        // 10y-2y and 10y-3mo spread
        public static string FredCycleSpread =
            "SELECT a.business_date, " +
            "       b.economic_index - a.economic_index spread10y_2y, " +
            "       b.economic_index - c.economic_index spreadb10y_3m " +
            "FROM FRED_DGS2 a " +
            "     INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            "     LEFT JOIN FRED_DGS3MO c ON a.business_date = c.business_date " +
            "ORDER BY a.business_date ";

        //일간 10-Year Treasury Constant Maturity Minus Federal Funds Rate and Ted Spread
        public static string FredDgs10DffSpreadAndTedRate =
            "SELECT a.business_date, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM FRED_DGS10 a " +
            "       INNER JOIN FRED_DFF b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity
        public static string FredDgs10Dgs3moSpread =
            "SELECT a.business_date, " +
            "       b.economic_index - a.economic_index spread " +
            "  FROM FRED_DGS3MO a " +
            "       INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 10-Year Treasury Constant Maturity Minus DBAA
        public static string FredDgs10DbaaSpread =
            "SELECT a.business_date, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM FRED_DBAA a " +
            "       INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //
        public static string FredDgs10Dgs2SpreadCompareDexkous =
            "select " +
            "  a.business_date " +
            " ,a.economic_index as DEXKOUS " +
            " ,b.spread " +
            "from FRED_DEXKOUS a " +
            "inner join ( " +
            "SELECT a.business_date, " +
            "       b.economic_index - a.economic_index spread " +
            "  FROM FRED_DGS2 a " +
            "       INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            ") b on a.business_date=b.business_date " +
            "order by a.business_date";

        //일간 10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity
        public static string FredDgs10Dgs2Spread =
            "SELECT a.business_date, " +
            "       b.economic_index - a.economic_index spread " +
            "  FROM FRED_DGS2 a " +
            "       INNER JOIN FRED_DGS10 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 5-Year Treasury Constant Maturity Minus 5-Year Treasury Inflation-Indexed Security Constant Maturity
        public static string FredDgs5Dfii5Spread =
            "SELECT a.business_date, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM FRED_DGS5 a " +
            "       INNER JOIN FRED_DFII5 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 10-Year Treasury Constant Maturity Minus 10-Year Treasury Inflation-Indexed Security Constant Maturity
        public static string FredDgs10Dfii10Spread =
            "SELECT a.business_date, " +
            "       a.economic_index - b.economic_index spread " +
            "  FROM FRED_DGS10 a " +
            "       INNER JOIN FRED_DFII10 b ON a.business_date = b.business_date " +
            "ORDER BY a.business_date ";

        //일간 U.S. Treasury 채권 동향
        public static string FredTbStatus =
            "SELECT a.business_date, " +
            "       a.economic_index, " +
            "       b.economic_index, " +
            "       f.economic_index, " +
            "       h.economic_index " +
            "  FROM FRED_DGS3MO a " +
            "       LEFT JOIN fred_dgs2 b ON a.business_date = b.business_date " +
            "       LEFT JOIN fred_dgs10 f ON a.business_date = f.business_date " +
            "       LEFT JOIN fred_dgs30 h ON a.business_date = h.business_date " +
            "ORDER BY a.business_date ";

        #endregion

        #region Fred Commodities
        // Crude Oil Prices: West Texas Intermediate (WTI) - Cushing, Oklahoma
        public static string FredWti =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DCOILWTICO " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Crude Oil Prices: Brent - Europe
        public static string FredBrent =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DCOILBRENTEU " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Conventional Gasoline Prices: U.S. Gulf Coast, Regular
        public static string FredGasolinePrice =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DGASUSGULF " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Henry Hub Natural Gas Spot Price
        public static string FredNaturalGasPrice =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DHHNGSP " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Kerosene-Type Jet Fuel Prices: U.S. Gulf Coast
        public static string FredJetFuelPrice =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DJFUELUSGULF " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Propane Prices: Mont Belvieu, Texas
        public static string FredPropanePrice =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DPROPANEMBTX " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // No. 2 Heating Oil Prices: New York Harbor
        public static string FredHeatingOilPrice =
            "SELECT " +
            "  a.date, " +
            "  a.value, " +
            "  AVG(a.value) OVER (ORDER BY a.date ROWS 2 PRECEDING) sma3, " +
            "  (((a.value / LAG(a.value, 12) OVER (ORDER BY a.date)) - 1) * 100) pcya " +
            "FROM (SELECT " +
            "  CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01')) date, " +
            "  AVG(economic_index) value " +
            "FROM FRED_DHOILNYH " +
            "GROUP BY CONVERT(date, concat(format(business_date, 'yyyy-MM'), '-01'))) a ";

        // Global price of Iron Oreⓒ
        public static string FredIronOrePrice =
            " SELECT" +
            " business_date" +
            " ,economic_index" +
            " ,AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3" +
            " ,(((economic_index / LAG(economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100) pcya" +
            " FROM FRED_PIORECRUSDM" +
            " ORDER BY business_date";

        // Global price of Coal, Australiaⓒ
        public static string FredCoalPrice =
            " SELECT" +
            " business_date" +
            " ,economic_index" +
            " ,AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3" +
            " ,(((economic_index / LAG(economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100) pcya" +
            " FROM FRED_PCOALAUUSDM" +
            " ORDER BY business_date";

        // Global price of Cottonⓒ
        public static string FredCottonPrice =
            " SELECT" +
            " business_date" +
            " ,economic_index" +
            " ,AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3" +
            " ,(((economic_index / LAG(economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100) pcya" +
            " FROM FRED_PCOTTINDUSDM" +
            " ORDER BY business_date";

        // Global price of Palm Oilⓒ
        public static string FredPalmOilPrice =
            " SELECT" +
            " business_date" +
            " ,economic_index" +
            " ,AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3" +
            " ,(((economic_index / LAG(economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100) pcya" +
            " FROM FRED_PPOILUSDM" +
            " ORDER BY business_date";

        // Global price of Wheatⓒ
        public static string FredWheatPrice =
            " SELECT" +
            " business_date" +
            " ,economic_index" +
            " ,AVG(economic_index) OVER (ORDER BY business_date ROWS 2 PRECEDING) sma3" +
            " ,(((economic_index / LAG(economic_index, 12) OVER (ORDER BY business_date)) - 1) * 100) pcya" +
            " FROM FRED_PWHEAMTUSDM" +
            " ORDER BY business_date";

        // Gas Margin
        public static string FredGasWtiMargin =
            "select " +
            "a.business_date " +
            ",(a.economic_index*42)-b.economic_index margin " +
            "from FRED_DGASUSGULF a " +
            "inner join FRED_DCOILWTICO b on a.business_date = b.business_date " +
            "order by a.business_date ";


        // Diesel Margin
        public static string FredDieselWtiMargin =
            "select " +
            "a.business_date " +
            ",(a.economic_index*42)-b.economic_index margin " +
            "from FRED_DDFUELUSGULF a " +
            "inner join FRED_DCOILWTICO b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // Jet Margin
        public static string FredJetWtiMargin =
            "select " +
            "a.business_date " +
            ",(a.economic_index*42)-b.economic_index margin " +
            "from FRED_DJFUELUSGULF a " +
            "inner join FRED_DCOILWTICO b on a.business_date = b.business_date " +
            "order by a.business_date ";

        // Propane Margin
        public static string FredPropaneWtiMargin =
            "select " +
            "a.business_date " +
            ",(a.economic_index*42)-b.economic_index margin " +
            "from FRED_DPROPANEMBTX a " +
            "inner join FRED_DCOILWTICO b on a.business_date = b.business_date " +
            "order by a.business_date ";

        //일간 ECOS 채권 동향
        public static string BojJtbStatus =
                "SELECT a.business_date " +
                "      ,a.economic_index AS y1 " +
                "      ,b.economic_index AS y2 " +
                "      ,c.economic_index AS y3 " +
                "      ,d.economic_index AS y5 " +
                "      ,e.economic_index AS y7 " +
                "      ,f.economic_index AS y10 " +
                "      ,g.economic_index AS y20 " +
                "      ,h.economic_index AS y30 " +
                "FROM QUANDL_INTEREST_RATE_JAPAN_1Y a " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_2Y b " +
                "        ON a.business_date = b.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_3Y c " +
                "        ON a.business_date = c.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_5Y d " +
                "        ON a.business_date = d.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_7Y e " +
                "        ON a.business_date = e.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_10Y f " +
                "        ON a.business_date = f.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_20Y g " +
                "        ON a.business_date = g.business_date " +
                "     INNER JOIN QUANDL_INTEREST_RATE_JAPAN_30Y h " +
                "        ON a.business_date = h.business_date " +
                "ORDER BY a.business_date ";

        // Heating Oil Margin
        public static string FredHeatingOilWtiMargin =
            "select " +
            "a.business_date " +
            ",(a.economic_index*42)-b.economic_index margin " +
            "from FRED_DHOILNYH a " +
            "inner join FRED_DCOILWTICO b on a.business_date = b.business_date " +
            "order by a.business_date ";



        #endregion

        #region Yahoo Series
        public static string YahooEtfEdvVsDgs20 =
            "select  " +
            "a.business_date " +
            ",a.economic_index as edv " +
            ",b.economic_index as dgs20 " +
            "from YAHOO_EDV a " +
            "inner join FRED_DGS20 b on a.business_date=b.business_date " +
            "order by a.business_date ";


        public static string YahooEtfTltVsDgs20 =
            "select  " +
            "a.business_date " +
            ",a.economic_index as tlt " +
            ",b.economic_index as dgs20 " +
            "from YAHOO_TLT a " +
            "inner join FRED_DGS20 b on a.business_date=b.business_date " +
            "order by a.business_date ";


        #endregion
    }
}