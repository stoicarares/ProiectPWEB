PGDMP                      |           mobylab-app    13.2    16.2 3    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16384    mobylab-app    DATABASE     x   CREATE DATABASE "mobylab-app" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';
    DROP DATABASE "mobylab-app";
                mobylab-app    false                        2615    2200    public    SCHEMA     2   -- *not* creating schema, since initdb creates it
 2   -- *not* dropping schema, since initdb creates it
                mobylab-app    false                       0    0    SCHEMA public    ACL     Q   REVOKE USAGE ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO PUBLIC;
                   mobylab-app    false    5                        3079    16391    unaccent 	   EXTENSION     <   CREATE EXTENSION IF NOT EXISTS unaccent WITH SCHEMA public;
    DROP EXTENSION unaccent;
                   false    5                       0    0    EXTENSION unaccent    COMMENT     P   COMMENT ON EXTENSION unaccent IS 'text search dictionary that removes accents';
                        false    2            �            1259    24710    Address    TABLE     �  CREATE TABLE public."Address" (
    "Id" uuid NOT NULL,
    "Street" character varying(400) NOT NULL,
    "Number" integer NOT NULL,
    "City" character varying(100) NOT NULL,
    "State" character varying(100) NOT NULL,
    "Country" character varying(100) NOT NULL,
    "PostalCode" character varying(100) NOT NULL,
    "UserId" uuid NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."Address";
       public         heap    mobylab-app    false    5            �            1259    24724    Order    TABLE       CREATE TABLE public."Order" (
    "Id" uuid NOT NULL,
    "ShoppingCartId" uuid NOT NULL,
    "PaymentMethod" text NOT NULL,
    "ShippingMethod" text NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."Order";
       public         heap    mobylab-app    false    5            �            1259    24622    Product    TABLE     u  CREATE TABLE public."Product" (
    "Id" uuid NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Description" character varying(1000),
    "Price" numeric NOT NULL,
    "Stock" integer NOT NULL,
    "Image" text NOT NULL,
    "Quantity" integer NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."Product";
       public         heap    mobylab-app    false    5            �            1259    24684    ProductShoppingCart    TABLE     s   CREATE TABLE public."ProductShoppingCart" (
    "ProductsId" uuid NOT NULL,
    "ShoppingCartsId" uuid NOT NULL
);
 )   DROP TABLE public."ProductShoppingCart";
       public         heap    mobylab-app    false    5            �            1259    24640    Review    TABLE     [  CREATE TABLE public."Review" (
    "Id" uuid NOT NULL,
    "Title" character varying(255) NOT NULL,
    "Content" character varying(5000),
    "Rating" integer NOT NULL,
    "UserId" uuid NOT NULL,
    "ReviewedProductId" uuid NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."Review";
       public         heap    mobylab-app    false    5            �            1259    24658    ShoppingCart    TABLE       CREATE TABLE public."ShoppingCart" (
    "Id" uuid NOT NULL,
    "TotalPrice" numeric NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);
 "   DROP TABLE public."ShoppingCart";
       public         heap    mobylab-app    false    5            �            1259    24630    User    TABLE     X  CREATE TABLE public."User" (
    "Id" uuid NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Email" character varying(255) NOT NULL,
    "Password" character varying(255) NOT NULL,
    "Role" character varying(255) NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."User";
       public         heap    mobylab-app    false    5            �            1259    24671    UserFile    TABLE     F  CREATE TABLE public."UserFile" (
    "Id" uuid NOT NULL,
    "Path" character varying(255) NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Description" character varying(4095),
    "UserId" uuid NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "UpdatedAt" timestamp without time zone NOT NULL
);
    DROP TABLE public."UserFile";
       public         heap    mobylab-app    false    5            �            1259    16385    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    mobylab-app    false    5            �          0    24710    Address 
   TABLE DATA           �   COPY public."Address" ("Id", "Street", "Number", "City", "State", "Country", "PostalCode", "UserId", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    208   QC       �          0    24724    Order 
   TABLE DATA           v   COPY public."Order" ("Id", "ShoppingCartId", "PaymentMethod", "ShippingMethod", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    209   D       �          0    24622    Product 
   TABLE DATA           �   COPY public."Product" ("Id", "Name", "Description", "Price", "Stock", "Image", "Quantity", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    202   YE       �          0    24684    ProductShoppingCart 
   TABLE DATA           P   COPY public."ProductShoppingCart" ("ProductsId", "ShoppingCartsId") FROM stdin;
    public          mobylab-app    false    207   %F       �          0    24640    Review 
   TABLE DATA              COPY public."Review" ("Id", "Title", "Content", "Rating", "UserId", "ReviewedProductId", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    204   �F       �          0    24658    ShoppingCart 
   TABLE DATA           `   COPY public."ShoppingCart" ("Id", "TotalPrice", "CreatedAt", "UpdatedAt", "UserId") FROM stdin;
    public          mobylab-app    false    205   rG       �          0    24630    User 
   TABLE DATA           e   COPY public."User" ("Id", "Name", "Email", "Password", "Role", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    203   I       �          0    24671    UserFile 
   TABLE DATA           m   COPY public."UserFile" ("Id", "Path", "Name", "Description", "UserId", "CreatedAt", "UpdatedAt") FROM stdin;
    public          mobylab-app    false    206   1L       �          0    16385    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          mobylab-app    false    201   NL       T           2606    24639    User AK_User_Email 
   CONSTRAINT     T   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "AK_User_Email" UNIQUE ("Email");
 @   ALTER TABLE ONLY public."User" DROP CONSTRAINT "AK_User_Email";
       public            mobylab-app    false    203            f           2606    24717    Address PK_Address 
   CONSTRAINT     V   ALTER TABLE ONLY public."Address"
    ADD CONSTRAINT "PK_Address" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Address" DROP CONSTRAINT "PK_Address";
       public            mobylab-app    false    208            i           2606    24731    Order PK_Order 
   CONSTRAINT     R   ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "PK_Order" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Order" DROP CONSTRAINT "PK_Order";
       public            mobylab-app    false    209            R           2606    24629    Product PK_Product 
   CONSTRAINT     V   ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "PK_Product" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Product" DROP CONSTRAINT "PK_Product";
       public            mobylab-app    false    202            c           2606    24688 *   ProductShoppingCart PK_ProductShoppingCart 
   CONSTRAINT     �   ALTER TABLE ONLY public."ProductShoppingCart"
    ADD CONSTRAINT "PK_ProductShoppingCart" PRIMARY KEY ("ProductsId", "ShoppingCartsId");
 X   ALTER TABLE ONLY public."ProductShoppingCart" DROP CONSTRAINT "PK_ProductShoppingCart";
       public            mobylab-app    false    207    207            Z           2606    24647    Review PK_Review 
   CONSTRAINT     T   ALTER TABLE ONLY public."Review"
    ADD CONSTRAINT "PK_Review" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Review" DROP CONSTRAINT "PK_Review";
       public            mobylab-app    false    204            ]           2606    24665    ShoppingCart PK_ShoppingCart 
   CONSTRAINT     `   ALTER TABLE ONLY public."ShoppingCart"
    ADD CONSTRAINT "PK_ShoppingCart" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."ShoppingCart" DROP CONSTRAINT "PK_ShoppingCart";
       public            mobylab-app    false    205            V           2606    24637    User PK_User 
   CONSTRAINT     P   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "PK_User" PRIMARY KEY ("Id");
 :   ALTER TABLE ONLY public."User" DROP CONSTRAINT "PK_User";
       public            mobylab-app    false    203            `           2606    24678    UserFile PK_UserFile 
   CONSTRAINT     X   ALTER TABLE ONLY public."UserFile"
    ADD CONSTRAINT "PK_UserFile" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."UserFile" DROP CONSTRAINT "PK_UserFile";
       public            mobylab-app    false    206            P           2606    16389 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            mobylab-app    false    201            d           1259    24723    IX_Address_UserId    INDEX     M   CREATE INDEX "IX_Address_UserId" ON public."Address" USING btree ("UserId");
 '   DROP INDEX public."IX_Address_UserId";
       public            mobylab-app    false    208            g           1259    24737    IX_Order_ShoppingCartId    INDEX     `   CREATE UNIQUE INDEX "IX_Order_ShoppingCartId" ON public."Order" USING btree ("ShoppingCartId");
 -   DROP INDEX public."IX_Order_ShoppingCartId";
       public            mobylab-app    false    209            a           1259    24699 &   IX_ProductShoppingCart_ShoppingCartsId    INDEX     w   CREATE INDEX "IX_ProductShoppingCart_ShoppingCartsId" ON public."ProductShoppingCart" USING btree ("ShoppingCartsId");
 <   DROP INDEX public."IX_ProductShoppingCart_ShoppingCartsId";
       public            mobylab-app    false    207            W           1259    24700    IX_Review_ReviewedProductId    INDEX     a   CREATE INDEX "IX_Review_ReviewedProductId" ON public."Review" USING btree ("ReviewedProductId");
 1   DROP INDEX public."IX_Review_ReviewedProductId";
       public            mobylab-app    false    204            X           1259    24701    IX_Review_UserId    INDEX     K   CREATE INDEX "IX_Review_UserId" ON public."Review" USING btree ("UserId");
 &   DROP INDEX public."IX_Review_UserId";
       public            mobylab-app    false    204            [           1259    24704    IX_ShoppingCart_UserId    INDEX     ^   CREATE UNIQUE INDEX "IX_ShoppingCart_UserId" ON public."ShoppingCart" USING btree ("UserId");
 ,   DROP INDEX public."IX_ShoppingCart_UserId";
       public            mobylab-app    false    205            ^           1259    24702    IX_UserFile_UserId    INDEX     O   CREATE INDEX "IX_UserFile_UserId" ON public."UserFile" USING btree ("UserId");
 (   DROP INDEX public."IX_UserFile_UserId";
       public            mobylab-app    false    206            p           2606    24718    Address FK_Address_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Address"
    ADD CONSTRAINT "FK_Address_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 L   ALTER TABLE ONLY public."Address" DROP CONSTRAINT "FK_Address_User_UserId";
       public          mobylab-app    false    203    2902    208            q           2606    24732 *   Order FK_Order_ShoppingCart_ShoppingCartId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "FK_Order_ShoppingCart_ShoppingCartId" FOREIGN KEY ("ShoppingCartId") REFERENCES public."ShoppingCart"("Id") ON DELETE CASCADE;
 X   ALTER TABLE ONLY public."Order" DROP CONSTRAINT "FK_Order_ShoppingCart_ShoppingCartId";
       public          mobylab-app    false    2909    205    209            n           2606    24689 =   ProductShoppingCart FK_ProductShoppingCart_Product_ProductsId    FK CONSTRAINT     �   ALTER TABLE ONLY public."ProductShoppingCart"
    ADD CONSTRAINT "FK_ProductShoppingCart_Product_ProductsId" FOREIGN KEY ("ProductsId") REFERENCES public."Product"("Id") ON DELETE CASCADE;
 k   ALTER TABLE ONLY public."ProductShoppingCart" DROP CONSTRAINT "FK_ProductShoppingCart_Product_ProductsId";
       public          mobylab-app    false    2898    207    202            o           2606    24694 G   ProductShoppingCart FK_ProductShoppingCart_ShoppingCart_ShoppingCartsId    FK CONSTRAINT     �   ALTER TABLE ONLY public."ProductShoppingCart"
    ADD CONSTRAINT "FK_ProductShoppingCart_ShoppingCart_ShoppingCartsId" FOREIGN KEY ("ShoppingCartsId") REFERENCES public."ShoppingCart"("Id") ON DELETE CASCADE;
 u   ALTER TABLE ONLY public."ProductShoppingCart" DROP CONSTRAINT "FK_ProductShoppingCart_ShoppingCart_ShoppingCartsId";
       public          mobylab-app    false    2909    207    205            j           2606    24648 *   Review FK_Review_Product_ReviewedProductId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Review"
    ADD CONSTRAINT "FK_Review_Product_ReviewedProductId" FOREIGN KEY ("ReviewedProductId") REFERENCES public."Product"("Id") ON DELETE CASCADE;
 X   ALTER TABLE ONLY public."Review" DROP CONSTRAINT "FK_Review_Product_ReviewedProductId";
       public          mobylab-app    false    2898    204    202            k           2606    24653    Review FK_Review_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Review"
    ADD CONSTRAINT "FK_Review_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 J   ALTER TABLE ONLY public."Review" DROP CONSTRAINT "FK_Review_User_UserId";
       public          mobylab-app    false    204    203    2902            l           2606    24705 (   ShoppingCart FK_ShoppingCart_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShoppingCart"
    ADD CONSTRAINT "FK_ShoppingCart_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 V   ALTER TABLE ONLY public."ShoppingCart" DROP CONSTRAINT "FK_ShoppingCart_User_UserId";
       public          mobylab-app    false    205    203    2902            m           2606    24679     UserFile FK_UserFile_User_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."UserFile"
    ADD CONSTRAINT "FK_UserFile_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") ON DELETE CASCADE;
 N   ALTER TABLE ONLY public."UserFile" DROP CONSTRAINT "FK_UserFile_User_UserId";
       public          mobylab-app    false    203    206    2902            �   �   x�}�1n1��+�(iER�����IGp��?H��@�jg1� T��Jrd!�.4�0�l�T�����~��|,��?����DI�f�%�IJU��͖�ĠR�26��Z�V�B���*�+UpU�B�kw���_��9�ߏ2�O�@#����怄zw�s�m�l9�,��B�tZSJ?"'T�      �   5  x���ˊA���O1/��r�Tz��~�M��ҿ�����q΁�|�\}:+���v���;Z�3J�ڽ���<F�m�A��)�O����x���{�Ƿ��ۼe��/��%|���~ ��.�
j\@�ێ�ۚ�Z��g_i[&�!���L���S;Ja�&���(_$�"+�Kvt���B��U	vLT-^rXZ�#
`T��C4Xm�l��Ė���>��~���D�X/���>@>��U�V��d*�@c�OѮ��Dn=Ѫ���ַ	3�ҵ)����^��k|��:|e��Nr��%=>��q�M�|      �   �   x�U��m� ��
 ��0PE
��V�����x�DINs���m�T��քNXȵA�rl�`Vip��s���?�1����q P��c�o��(�� ��b*J���%�U.�
e�b�f*��KwK����\ף9��������}��w�>�[��[��
$?dQ
]O�SN��"�.E�33���7�|�:@�      �   �   x����q 1Dѳ'\�.r�$�?+���~գd�~��H�@X(7��P<�g�ؕ��@4nt�E�n�g�vT2��T_���U����i
GHuiY��ؽ��I�ژi��n��Y�0u���wc}�h�rp��o�bt�1�DC�H����<��_3      �   �   x�}�91@�:9�(�ezN@K;N�B q��P~��7��i1�n�T�����r�e#\�~����	D"IA�،`�~fMn}���%X:�	�-��ҋ+9��.y��	�%�Ni'٘�0��x�b�RP-�      �   �  x�}���$1�(6ğHN,����qq�=��L��Xl5��>ave�5'��cږ�c⫽��@ |#?��[�E����h��l�8���݇��h}]���"	d�Alp_z�����'�Q���ݻQ��"fU$NH�
2'�XQGk{��].�1sЀ�VhĢ=rK����E��~�?�I�8�~EZx[����S�)���O�L��vl��Ϧ��Ԭ.�C�!�:Q:���O�.�5k��:��W��A�	�+�,�ݡX�k9@g�䔘����q�8��R�0��\�YUbc~������N�A����^rO@��5'n�I�lۖW.,�	ұA=���e�~�>��p��a{�ܤb�/gE�
IY~�~�Y�T7V����}]�_�G��      �     x���ko�8�?�_����/H#��(�`���v�@��k[��kfv����VNlE����=�1�$�Pz��s�
)�$:VA���a\���ME_���y}Zc[�V&���O���Cٝ����#k�Ў��l�u~�%lSr���O0�@
0�C�U�3.��!E�@8��	�j�1�Pc����q���Q��4����.���r�6c���7|� ��t�9_+��;��`�R�8�!E�`i
�[P90�(��*� �+{�w�����ݼm���_wG�M��b��G�y������m�B2�̳Ÿ(�?İFT	�\ސ"BC�`�e�ZK��U��Y�F�V�:<�[�Q���8i�b�6̥C��v�S�T\&��v��D�`^�^��Op���5c&�P�yn�G��i���WKo�5�{ᔓT����1*��zQ��Y_&u�,���f��tR�Z�۴�!f�4����w�����R5�B;��������\NeHa&��h��Q�X���C�ʥ�����mhlp��ݐ"�5֞S��U�*i�f�a1V�;ᄩs}+u�z��_X�8��S�����~l��z��S���O��O�p����1�aH�)��sCLÌ e���!��Ҙ��l�J�d���j��l�Q�9�s�w�}�ǉo�̢��.�?E
EY��X(��R��#$���:��@�Y�� Va=�^�m��W;�e��?f��֯�=}�irz����)����H(�1	���GQ�'`(~�      �      x������ � �      �   �   x����
�0�y��l~j�DЃxB C-�
IA|{�/D����C��4J�va?tc�}F�r���4�JQc��I鈇�c)(K�Y��m�[��v���x^
���FQ�8�H����`�g��\��_����ӟH�2���Z�fM�&s�\+!��S
     