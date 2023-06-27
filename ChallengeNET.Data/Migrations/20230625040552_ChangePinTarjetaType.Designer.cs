﻿// <auto-generated />
using System;
using ChallengeNET.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChallengeNET.DataAccess.Migrations
{
    [DbContext(typeof(OperacionContext))]
    [Migration("20230625040552_ChangePinTarjetaType")]
    partial class ChangePinTarjetaType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Balance", b =>
                {
                    b.Property<int>("balance_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("balance_id"));

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.Property<int>("tarjeta_id")
                        .HasColumnType("int");

                    b.HasKey("balance_id");

                    b.HasIndex("tarjeta_id");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Operacion", b =>
                {
                    b.Property<int>("operacion_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("operacion_id"));

                    b.Property<string>("cod_operacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fecha_operacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("tarjeta_id")
                        .HasColumnType("int");

                    b.HasKey("operacion_id");

                    b.HasIndex("tarjeta_id");

                    b.ToTable("Operaciones");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Retiro", b =>
                {
                    b.Property<int>("retiro_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("retiro_id"));

                    b.Property<DateTime>("fecha_retiro")
                        .HasColumnType("datetime2");

                    b.Property<double>("monto_retiro")
                        .HasColumnType("float");

                    b.Property<int>("operacion_id")
                        .HasColumnType("int");

                    b.Property<int>("tarjeta_id")
                        .HasColumnType("int");

                    b.HasKey("retiro_id");

                    b.HasIndex("operacion_id");

                    b.HasIndex("tarjeta_id");

                    b.ToTable("Retiros");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Tarjeta", b =>
                {
                    b.Property<int>("tarjeta_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tarjeta_id"));

                    b.Property<string>("nro_tarjeta")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("pin_tarjeta")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<bool>("tarjeta_bloqueada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("vencimiento_tarjeta")
                        .HasColumnType("datetime2");

                    b.HasKey("tarjeta_id");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Balance", b =>
                {
                    b.HasOne("ChallengeNET.DataAccess.Entitys.Tarjeta", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("tarjeta_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Operacion", b =>
                {
                    b.HasOne("ChallengeNET.DataAccess.Entitys.Tarjeta", "Tarjeta")
                        .WithMany("Operaciones")
                        .HasForeignKey("tarjeta_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Retiro", b =>
                {
                    b.HasOne("ChallengeNET.DataAccess.Entitys.Operacion", "Operacion")
                        .WithMany()
                        .HasForeignKey("operacion_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChallengeNET.DataAccess.Entitys.Tarjeta", "Tarjeta")
                        .WithMany("Retiros")
                        .HasForeignKey("tarjeta_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operacion");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("ChallengeNET.DataAccess.Entitys.Tarjeta", b =>
                {
                    b.Navigation("Operaciones");

                    b.Navigation("Retiros");
                });
#pragma warning restore 612, 618
        }
    }
}