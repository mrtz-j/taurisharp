{
  sources ? import ./npins,
  system ? builtins.currentSystem,
  pkgs ?
    import sources.nixpkgs {
      inherit system;
      config = {};
      overlays = [(import sources.rust-overlay)];
    },
}: {
  shell = pkgs.mkShell {
    name = "taurisharp";
    nativeBuildInputs = with pkgs;
      [
        rust-bin.stable.latest.default
        bun
        dotnet-sdk_8
      ]
      ++ lib.optionals (pkgs.stdenv.isDarwin) (with pkgs;
        with darwin.apple_sdk.frameworks; [
          CoreFoundation
          CoreServices
          SystemConfiguration
          WebKit
        ]);

    RUST_BACKTRACE = "1";
  };
}
